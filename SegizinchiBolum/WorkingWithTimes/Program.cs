﻿using static System.Console;
using System.Globalization;

WriteLine($"Earliest date.time value - {DateTime.MinValue}");
WriteLine($"Unix Epoch date.time value - {DateTime.UnixEpoch}");
WriteLine($"Now date.time value - {DateTime.Now}");
WriteLine($"Today date.time value - {DateTime.Today}");
WriteLine();

DateTime newYear = new DateTime(year: 2023, month: 12, day: 31);
WriteLine($"New Year - {newYear}");
WriteLine($"New Year - {newYear:dddd, dd MMMM yyyy}");
WriteLine($"New Year - {newYear.Month}");
WriteLine($"New Year - {newYear.DayOfYear}");
WriteLine($"New Year - {newYear.Year}");
WriteLine($"New Year - {newYear.DayOfWeek}");
WriteLine();

// Subs Add

DateTime beforeNewYear = newYear.Subtract(TimeSpan.FromDays(19));
//DateTime afterNewYear = newYear.Add(TimeSpan.FromDays(34));
DateTime afterNewYear = newYear.AddDays(34);
WriteLine($"19 days before New Year is {beforeNewYear}");
WriteLine($"34 days after New Year is {afterNewYear}");

TimeSpan untillNewYear = newYear - DateTime.Now;
WriteLine($"There are {untillNewYear.Days} days and {untillNewYear.Hours} hours left");
WriteLine($"There total hours untill New Year: {untillNewYear.TotalHours:N0}");
WriteLine($"{DateTime.Now.ToShortTimeString()} - {DateTime.Now.ToShortDateString()}");
WriteLine();

// Culture Info
WriteLine($"Current culture is \"{CultureInfo.CurrentCulture.Name}\"");
for (int year = 2020; year < 2026; year++)
{
    Write($"{year} is a leap year? -> {DateTime.IsLeapYear(year)} ");
    WriteLine($"February days: {DateTime.DaysInMonth(year, 2)}");
}
WriteLine();

// DateOnly and TimeOnly

DateOnly duaBDay = new DateOnly(year: 2024, month: 7, day: 22);
WriteLine($"Dua's next bday is {duaBDay}");
TimeOnly party = new(hour: 19, minute: 45);
WriteLine($"Dua's bday party starts at {party}");

DateTime saveCalendar = duaBDay.ToDateTime(party);
WriteLine($"Add to your calendar {saveCalendar}");
WriteLine();