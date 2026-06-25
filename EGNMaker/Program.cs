using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

class Program
{
	public static void Main(string[] args)
	{
		Console.Write("Enter gender(0-Male; 1-Female): ");
		int gender = int.Parse(Console.ReadLine());
		Console.Write("Enter birth region: ");
		string region = Console.ReadLine();
		Console.Write("Enter day of birth: ");
		int dayBirth = int.Parse(Console.ReadLine());
		Console.Write("Enter month of birth: ");
		int monthBirth = int.Parse(Console.ReadLine());
		Console.Write("Enter year of birth: ");
		int yearBirth = int.Parse(Console.ReadLine());
		// All the information that is comming from the user

		string YY = $"{(yearBirth / 10) % 10}{yearBirth % 10}"; // YY for the final string

		if (yearBirth > 1800 && yearBirth < 1900)
			monthBirth += 20;
		else if (yearBirth > 2000 && yearBirth < 2100)
			monthBirth += 40;
		string MM = monthBirth.ToString("D2"); // MM for the final string
		string DD = dayBirth.ToString("D2"); // DD for the final string

		string first6Digits = YY + MM + DD;

		var regions = new Dictionary<string, (int Start, int End)>
		  {
				{"Blagoevgrad", (0, 43)},
					 {"Burgas", (44, 93)},
					 {"Varna", (94, 139)},
					 {"Veliko Tarnavo", (140, 169)},
					 {"Vidin", (170, 183)},
					 {"Vratsa", (184, 217)},
					 {"Gabrovo", (218, 233)},
					 {"Kardzhali", (234, 281)},
					 {"Kyustendil", (282, 301)},
					 {"Lovech", (302, 319)},
					 {"Montana", (320, 341)},
					 {"Pazardzhik", (342, 377)},
					 {"Pernik", (378, 395)},
					 {"Pleven", (396, 435)},
					 {"Plovdiv", (436, 501)},
					 {"Razgrad", (502, 527)},
					 {"Ruse", (528, 555)},
					 {"Silistra", (556, 575)},
					 {"Sliven", (576, 601)},
					 {"Smolyan", (602, 623)},
					 {"Sofia City", (624, 721)},
					 {"Sofia Region", (722, 751)},
					 {"Stara Zagora", (752, 789)},
					 {"Dobrich", (790, 821)},
					 {"Targovishte", (822, 843)},
					 {"Haskovo", (844, 871)},
					 {"Shumen", (872, 903)},
					 {"Yambol", (904, 925)},
					 {"Other/Unknown", (926, 999)}
		  };

		int start = regions[region].Start;
		int end = regions[region].End;

		for (int sss = start; sss < end; sss++)
		{
			int ninthDigit = sss % 10;

			if (gender == 0 && ninthDigit % 2 != 0)
				continue;
			if (gender == 1 && ninthDigit % 2 == 0)
				continue;

			string SSS = sss.ToString("D3");
			string first9Digits = first6Digits + SSS;

			int d1 = first9Digits[0] - '0';
			int d2 = first9Digits[1] - '0';
			int d3 = first9Digits[2] - '0';
			int d4 = first9Digits[3] - '0';
			int d5 = first9Digits[4] - '0';
			int d6 = first9Digits[5] - '0';
			int d7 = first9Digits[6] - '0';
			int d8 = first9Digits[7] - '0';
			int d9 = first9Digits[8] - '0';

			int sum =
				 d1 * 2 +
				 d2 * 4 +
				 d3 * 8 +
				 d4 * 5 +
				 d5 * 10 +
				 d6 * 9 +
				 d7 * 7 +
				 d8 * 3 +
				 d9 * 6;

			int checkedSum = sum % 11;

			if (checkedSum == 10)
				checkedSum = 0;

			string egn = first9Digits + checkedSum;
			Console.WriteLine(egn);
		}
	}
}
