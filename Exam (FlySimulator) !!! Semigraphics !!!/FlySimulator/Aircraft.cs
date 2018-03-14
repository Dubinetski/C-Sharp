using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlySimulator {
	public static class Aircraft {
		public const int SPEED_CHANGE_STEP = 50;
		public const int SPEED_FORCE_CHANGE_STEP = 150;
		public const int HEIGHT_CHANGE_STEP = 250;
		public const int HEIGHT_FORCE_CHANGE_STEP = 500;
		public const int MIN_COUNT_OF_DISPATCHERS = 2;
		public const int MAX_COUNT_OF_DISPATCHERS = 8;

		public static event Action<int, int> ChangeStateEvent;

		private static List<Dispatcher> dispetchers;
		private static int speed;
		private static int height;
		private static int minHeight;
		private static int maxHeight;
		private static int minRiskHeight;
		private static int maxRiskHeight;
		private static int minCrashHeight;
		private static int maxCrashHeight;
		private static int lowerPassageBorderEcart;
		private static int upperPassageBorderEcart;
		private static int summPenalty;
		private static bool isTestSpeedArrived;

		static Aircraft() {
			Dispatchers = new List<Dispatcher>();
			IsTestSpeedArrived = false;
		}

		public static int Height {
			get => height;
			private set {
				if (speed > 0 && value >= 0) {
					height = value;
					OnChangeStateEvent();
					UpdateAirPassageInfo(false);
					if (height>Dispatcher.MAX_SPEED) {
						IsTestSpeedArrived = true;
					}
				} else {
					throw new Warning("Aircraft is not fly-up yet.");
				}
			}
		}
		public static int Speed {
			get => speed;
			private set {
				if (height > 0 && value >= 0) {
					speed = value;
					OnChangeStateEvent();
					UpdateAirPassageInfo();
				} else {
					throw new Warning("Aircraft is not fly-up yet.");
				}
			}
		}
		public static int MinHeight { get => minHeight; private set => minHeight = value; }
		public static int MaxHeight { get => maxHeight; private set => maxHeight = value; }
		public static int MinRiskHeight { get => minRiskHeight; private set => minRiskHeight = value; }
		public static int MaxRiskHeight { get => maxRiskHeight; private set => maxRiskHeight = value; }
		public static int MinCrashHeight { get => minCrashHeight; private set => minCrashHeight = value; }
		public static int MaxCrashHeight { get => maxCrashHeight; private set => maxCrashHeight = value; }
		public static List<Dispatcher> Dispatchers { get => dispetchers; set => dispetchers = value; }
		public static int LowerPassageBorderEcart { get => lowerPassageBorderEcart; private set => lowerPassageBorderEcart = value; }
		public static int UpperPassageBorderEcart { get => upperPassageBorderEcart; set => upperPassageBorderEcart = value; }
		public static int SummPenalty { get => summPenalty; set => summPenalty = value; }
		public static bool IsTestSpeedArrived { get => isTestSpeedArrived; set => isTestSpeedArrived = value; }

		/// <summary>
		/// Добавить нового диспетчера
		/// </summary>
		/// <param name="name">Имя диспетчера</param>
		public static void AddDispatcher(string name) {
			if (Dispatchers.Count < MAX_COUNT_OF_DISPATCHERS) {
				Dispatchers.Add(new Dispatcher(name, Speed, Height));
				ChangeStateEvent += Dispatchers.Last().GetCurrentFlyInfo;
				UpdateAirPassageInfo();
			}
		}
		/// <summary>
		/// Удаление диспетчера
		/// </summary>
		/// <param name="dispIndex">Индекс диспетчера в списке</param>
		public static void DelDispatcher(int dispIndex) {
			if (dispIndex >= 0 && dispIndex < Dispatchers.Count) {
				if (Dispatchers.Count < MIN_COUNT_OF_DISPATCHERS && speed > 0) {
					throw new Warning("Impossibly. Need two or more despatchers for fly control");
				}
				SummPenalty += Dispatchers[dispIndex].Penalty;
				ChangeStateEvent -= Dispatchers[dispIndex].GetCurrentFlyInfo;
				Dispatchers.RemoveAt(dispIndex);
			}
		}
		/// <summary>
		/// Обработчик события изменения состояния (скрости/высоты полета) самолета
		/// </summary>
		public static void OnChangeStateEvent() {
			ChangeStateEvent?.Invoke(Speed, Height);
		}
		/// <summary>
		/// Обновить информацию о рекомендуемом воздушном коридоре
		/// </summary>
		/// <param name="isSpeedChenged">Изменяласть ли скорость полета?</param>
		private static void UpdateAirPassageInfo(bool isSpeedChenged = true) {
			if (isSpeedChenged) {
				int minRecomendHeight = 0;
				int maxRecomendHeight = 0;
				for (int i = 0; i < Dispatchers.Count; i++) {
					if (i == 0) {
						minRecomendHeight = maxRecomendHeight = Dispatchers[i].RecommendHeigth;
					} else {
						if (Dispatchers[i].RecommendHeigth > maxRecomendHeight)
							maxRecomendHeight = Dispatchers[i].RecommendHeigth;
						if (Dispatchers[i].RecommendHeigth < minRecomendHeight)
							minRecomendHeight = Dispatchers[i].RecommendHeigth;
					}
				}
				MinHeight = maxRecomendHeight - Dispatcher.PERMITTED_HEIGHT_ECART;
				MaxHeight = minRecomendHeight + Dispatcher.PERMITTED_HEIGHT_ECART;

				MinRiskHeight = maxRecomendHeight - Dispatcher.RISK_HEIGHT_ECART;
				MaxRiskHeight = minRecomendHeight + Dispatcher.RISK_HEIGHT_ECART;

				MinCrashHeight = maxRecomendHeight - Dispatcher.CRASH_HEIGHT_ECART;
				MaxCrashHeight = minRecomendHeight + Dispatcher.CRASH_HEIGHT_ECART;
			}
			if (Speed >= Dispatcher.MIN_CONTROL_SPEED) {
				LowerPassageBorderEcart = Height - MinHeight;
				UpperPassageBorderEcart = MaxHeight - Height;
			}
		}
		/// <summary>
		/// Взлететь или посадить самолет
		/// </summary>
		public static void StartOrStop() {
			if (Speed == 0 && Height == 0) {
				if (Dispatchers.Count < MIN_COUNT_OF_DISPATCHERS) 
					throw new Warning("Need two despatchers or more");
				speed = SPEED_CHANGE_STEP;
				height = HEIGHT_CHANGE_STEP;
				SummPenalty = 0;
			} else if (Speed == SPEED_CHANGE_STEP && Height == HEIGHT_CHANGE_STEP) {
				if (!IsTestSpeedArrived) 
					throw new GameOver("Test collapse. Test speed is't arrive.");
				speed = 0;
				height = 0;
				for (int i = 0; i < Dispatchers.Count; i++) {
					DelDispatcher(i);
				}
			}
			OnChangeStateEvent();
			UpdateAirPassageInfo();
		}
		/// <summary>
		/// Изменить скорость полета
		/// </summary>
		/// <param name="isIncrease"></param>
		public static void SpeedChange(bool isIncrease = true) {
			Speed += (SPEED_CHANGE_STEP * (isIncrease ? 1 : -1));
		}
		/// <summary>
		/// Форсированно изменить скорость полета
		/// </summary>
		/// <param name="isIncrease"></param>
		public static void SpeedForceChange(bool isIncrease = true) {
			Speed += (SPEED_FORCE_CHANGE_STEP * (isIncrease ? 1 : -1));
		}
		/// <summary>
		/// Изменить высоту полета
		/// </summary>
		/// <param name="isIncrease"></param>
		public static void HeightChange(bool isIncrease = true) {
			Height += (HEIGHT_CHANGE_STEP * (isIncrease ? 1 : -1));
		}
		/// <summary>
		/// Резкий набор высоты
		/// </summary>
		/// <param name="isIncrease"></param>
		public static void HeightForceChange(bool isIncrease = true) {
			Height += (HEIGHT_FORCE_CHANGE_STEP * (isIncrease ? 1 : -1));
		}
	}
}
