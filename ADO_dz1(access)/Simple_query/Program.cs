using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simple_query {
	class Program {
		static void Main(string[] args) {
			OleDbConnection connection = new OleDbConnection();
			try {
				connection.ConnectionString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source= .\med.mdb";
				connection.Open();
				OleDbCommand command = connection.CreateCommand();
				string query;

				Console.WriteLine("Полная информация о пациентах больницы:\n");
				query = @"SELECT patientName as Фамилия, patientFirstName as Имя, patientBirthDate as День_рождения FROM Patients";
				PrintTable(new OleDbCommand(query, connection));
				Console.WriteLine("\n=========================================\n");

				Console.WriteLine("Полная информация о врачах больницы:\n");
				query = @"SELECT doctorName as Фамилия, doctorFirstName as Имя, doctorProfession as Профессия FROM Doctors";
				PrintTable(new OleDbCommand(query, connection));
				Console.WriteLine("\n=========================================\n");

				Console.WriteLine("Список пациентов с указанием их лечащих врачей:\n");
				query = @"SELECT Patients.patientName as Пациент, Doctors.doctorName as Доктор 
						  FROM Patients INNER JOIN 
							   (Visits INNER JOIN Doctors ON Visits.visitDoctor = Doctors.doctorID)
										ON Visits.visitPatient = Patients.patientID ";
				PrintTable(new OleDbCommand(query, connection));
				Console.WriteLine("\n=========================================\n");

				Console.WriteLine("Информация о стоимостях посещений пациентами врачей:\n");
				query = @"SELECT patientName as Пациент, doctorName as Доктор, SUM(visitCostValue) as Стоимость 
						FROM (Patients INNER JOIN 
							 (Visits INNER JOIN Doctors ON Visits.visitDoctor = Doctors.doctorID) 
									 ON Visits.visitPatient = Patients.patientID)
							  INNER JOIN VisitCosts ON Visits.visitID =	VisitCosts.visitCostID
						GROUP BY doctorName, patientName
						ORDER BY SUM(visitCostValue) DESC";
				PrintTable(new OleDbCommand(query, connection));
				Console.WriteLine("\n=========================================\n");

				Console.WriteLine("Информация о поставленных диагнозах за период:"); 
				query = @"SELECT VisitCosts.visitCostFrom as Дата, Doctors.doctorName as Доктор, Visits.visitComment as Диагноз 
						FROM Doctors INNER JOIN 
							(Visits INNER JOIN VisitCosts ON Visits.visitID = VisitCosts.visitCostID)
									ON Visits.visitDoctor = Doctors.doctorID
						ORDER BY visitCostFrom";
				PrintTable(new OleDbCommand(query, connection));
				Console.WriteLine("\n=========================================\n");

				Console.WriteLine("Информация о самом дорогом визите к врачу:"); 
				query = @"SELECT patientName as Пациент, doctorName as Доктор, visitCostValue as Стоимость 
						FROM (Patients INNER JOIN
							 (Visits INNER JOIN Doctors ON Visits.visitDoctor = Doctors.doctorID) 
									 ON Visits.visitPatient = Patients.patientID)
							 INNER JOIN VisitCosts ON Visits.visitID = VisitCosts.visitCostID 
						WHERE VisitCosts.visitCostValue = (SELECT MAX(visitCostValue) FROM VisitCosts INNER JOIN Visits ON Visits.visitID = VisitCosts.visitCostID)";
				PrintTable(new OleDbCommand(query, connection));
				Console.WriteLine("\n=========================================\n");

				Console.WriteLine("Информация о количестве пациентов у каждого врача:"); 
				query = @"SELECT Doctors.doctorName as Доктор, COUNT(Patients.patientID) as Колличество_пациентов 
						FROM Doctors INNER JOIN 
							(Visits INNER JOIN Patients ON Visits.visitPatient = Patients.patientID)
									ON Visits.visitDoctor = Doctors.doctorID
						GROUP BY Doctors.doctorName";
				PrintTable(new OleDbCommand(query, connection));
				Console.WriteLine("\n=========================================\n");

				Console.WriteLine("Информация о суммарной стоимости посещений каждого врача:"); 
				query = @"SELECT Doctors.doctorName as Доктор, SUM(VisitCosts.visitCostValue) as Сумма 
						FROM Doctors INNER JOIN 
							(Visits INNER JOIN VisitCosts ON Visits.visitID = VisitCosts.visitCostID)
									ON Visits.visitDoctor = Doctors.doctorID
						GROUP BY Doctors.doctorName";
				PrintTable(new OleDbCommand(query, connection));
			} catch (Exception ex) { Console.WriteLine(ex.Message); } finally { connection.Close(); }
			Console.ReadKey();
		}

		static void PrintTable(OleDbCommand com) {
			OleDbDataReader reader = com.ExecuteReader();
			DateTime date;

			for (int i = 0; i < reader.FieldCount; i++) {
				Console.Write("{0,-15}", reader.GetName(i));
			}
			Console.WriteLine("\n");

			while (reader.Read() != false) {
				for (int i = 0; i < reader.FieldCount; i++) {
					if (DateTime.TryParse(reader[i].ToString(), out date)) {
						Console.Write("{0,-15:dd/MM/yyyy}", date);
					} else {
						Console.Write("{0,-15}", reader[i]);
					}
				}
				Console.WriteLine();
			}
		}
	}
}
