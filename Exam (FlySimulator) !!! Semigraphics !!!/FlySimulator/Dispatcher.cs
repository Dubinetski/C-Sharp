using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlySimulator {
	public class Dispatcher {
		public const int MIN_CONTROL_SPEED = 50;
		public const int PERMITTED_HEIGHT_ECART = 300;
		public const int RISK_HEIGHT_ECART = 600;
		public const int CRASH_HEIGHT_ECART = 1000;
		public const int MAX_SPEED = 1000;

		const int MIN_WEATHER_COEFFICIENT = -200;
		const int MAX_WEATHER_COEFFICIENT = 200;
		const int SPEED_COEFFICIENT = 7;
		const int HEIGHT_ECART_PENALTY = 25;
		const int RISK_HEIGHT_ECART_PENALTY = 50;
		const int MAX_PENALTY = 1000;
		const int MAX_SPEED_EXCEEDING_PENALTY = 100;

		private string name;
		private int weatherCoefficient;
		private int flySpeed;
		private int currentHeight;
		private int recommendHeigth;
		private int penalty;
		private int heightEcart;

		public Dispatcher(string name) : this(name, 0, 0) { }
		public Dispatcher(string name, int speed, int height) {
			Name = name;
			WeatherCoefficient = GetWeatherCoefficient();
			GetCurrentFlyInfo(speed, height);
		}
		public int RecommendHeigth {
			get { return (FlySpeed >= MIN_CONTROL_SPEED) ? recommendHeigth : 0; }
			private set => recommendHeigth = value;
		}
		public string Name { get => name; private set => name = value; }
		public int WeatherCoefficient { get => weatherCoefficient; private set => weatherCoefficient = value; }
		public int FlySpeed { get => flySpeed; private set => flySpeed = value; }
		public int CurrentHeight { get => currentHeight; private set => currentHeight = value; }
		public int Penalty { get => penalty; private set => penalty = value; }
		public int HeightEcart { get => heightEcart; private set => heightEcart = value; }
		/// <summary>
		/// Расчитать рекомендуемую высоту полета
		/// </summary>
		/// <param name="speed">Текущая скорость полета самолета</param>
		/// <returns>Рекомендуемая высота</returns>
		private int CalcRecommendHeigth(int speed) {
			return speed * SPEED_COEFFICIENT - WeatherCoefficient;
		}
		/// <summary>
		/// Получить погодный коэффициент
		/// </summary>
		/// <returns>Погодный коэффициент</returns>
		private int GetWeatherCoefficient() {
			Random rnd = new Random();
			return rnd.Next(MIN_WEATHER_COEFFICIENT, MAX_WEATHER_COEFFICIENT);
		}
		/// <summary>
		/// Проверить состояние полета
		/// </summary>
		public void CheckFly() {
			if (HeightEcart > PERMITTED_HEIGHT_ECART) {	  //превышено допустимое отклонение высоты полета
				if (HeightEcart < RISK_HEIGHT_ECART)	  //но отклонение не опасно
					Penalty += HEIGHT_ECART_PENALTY;
				else if (HeightEcart < CRASH_HEIGHT_ECART)//отклонение опасно но не критичное
					Penalty += RISK_HEIGHT_ECART_PENALTY;
				else
					throw new GameOver("Aircraft is smash!");

				if (Penalty >= MAX_PENALTY)				  // получено предельное значение штрафных очков
					throw new GameOver("Unfit for flight!");
			}
			if ((FlySpeed == 0 ^ CurrentHeight == 0)) 	 // скорость ИЛИ высота равны нулю 
				throw new GameOver("Aircraft is smash!");

			if (FlySpeed > MAX_SPEED) {					 //превышена максимально допустимая скорость
				Penalty += MAX_SPEED_EXCEEDING_PENALTY;
				throw new Warning("Immediately reduce speed to " + MAX_SPEED);
			}

		}
		/// <summary>
		/// Получить текущую информацию о полете
		/// </summary>
		/// <param name="speed">Текущая скорость полета</param>
		/// <param name="heigth">Текущая высота полета</param>
		public void GetCurrentFlyInfo(int speed, int heigth) {
			FlySpeed = speed;
			CurrentHeight = heigth;
			RecommendHeigth = CalcRecommendHeigth(speed);
			HeightEcart = Math.Abs(RecommendHeigth - CurrentHeight);
			CheckFly();
		}
	}
}
