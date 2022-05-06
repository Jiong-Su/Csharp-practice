// See https://aka.ms/new-console-template for more information
using System.Globalization;


Console.WriteLine("Take the following string 'Davis, Clyne, Fonte, Hooiveld, Shaw, Davis, Schneiderlin, Cork, Lallana, Rodriguez, Lambert' and give each player a shirt number, starting from 1, to create a string of the form: '1.Davis, 2.Clyne, 3.Fonte' etc ");


_players.Split(";").Where()
        .ToList()
        .ForEach(a => DateTime.Parse(a))
        .ToList()
        .ForEach(players => Console.WriteLine($"{players}"));



//string[] separatingStrings = { "<<", "..." };

//string text = "one<<two......three<four";
//System.Console.WriteLine($"Original text: '{text}'");

//string[] words = text.Split(separatingStrings, System.StringSplitOptions.RemoveEmptyEntries);
//System.Console.WriteLine($"{words.Length} substrings in text:");

//foreach (var word in words)
//{
//    System.Console.WriteLine(word);
//}

//var cultureInfo = new CultureInfo("en-US");
//string[] dateStrings = { "Friday, 10/04/2009", "Friday, April 10, 2009" };
//foreach (string dateString in dateStrings)
//{
//    try
//    {
//        var dateTime = DateTime.Parse(dateString);
//        Console.WriteLine(dateTime);
//    }
//    catch (FormatException)
//    {
//        Console.WriteLine("Unable to parse '{0}'", dateString);
//    }
//}
// The example displays the following output:
//       Unable to parse ' Friday, April 10, 2009'
//       4/10/2009 00:00:00

//var orderByAge = (from player in _players.Split(';')
//                 let s = player.Split(',')
//                 let date = DateTime.Parse(s[1].Trim())
//                 orderby(s[1]) descending
//                 select new
//                 {
//                     Name = s[0],
//                     Date = s[1],
//                     Old = DateTime.Now.Year - date.Year
//                 })

//                 ;
string Names = "Davis, Clyne, Fonte, Hooiveld, Shaw, Davis, Schneiderlin, Cork, Lallana, Rodriguez, Lambert";

var x = Names
.Split(',')
.Select((playerName, num) => (num + 1) + " , " + playerName.Trim())
.Aggregate((thisplayer, nextplayer) => thisplayer + " , " + nextplayer);
Console.WriteLine(x);
Console.WriteLine();

//var b=Names.Split(',').Zip(x,(x,y)=>x.","+y+1)

//orderByAge.ToList().ForEach(Console.WriteLine);
//Take the following string "Jason Puncheon, 26/06/1986; Jos Hooiveld, 
//    22/04/1983; Kelvin Davis, 29/09/1976; Luke Shaw, 12/07/1995; Gaston Ramirez,
//    02/12/1990; Adam Lallana, 10/05/1988" and turn it into an IEnumerable of
//    players in order of age (bonus to show the age in the output)

string _players = "jason puncheon, 26/06/1986; jos hooiveld, 22/04/1983; kelvin davis, 29/09/1976; luke shaw, 12/07/1995; gaston ramirez, 02/12/1990; adam lallana, 10/05/1988";
(from player in _players.Split(';')
 let s = player.Split(',')
 let date = DateTime.Parse(s[1].Trim())
 orderby (s[1]) descending
 select new { Name = s[0], DateOfBirth = s[1], Age = DateTime.Now.Year - date.Year })
         .ToList()
         .ForEach(Console.WriteLine);

Console.WriteLine();




string minutes = "4:12,2:43,3:51,4:29,3:24,3:14,4:46,3:25,4:52,3:27";
var albumLength = TimeSpan.FromSeconds((from time in minutes.Split(',')
                                        select TimeSpan.ParseExact(time, "m\\:ss", CultureInfo.InvariantCulture)
                                       .TotalSeconds)
                      .Sum());


Console.WriteLine(albumLength);

Console.WriteLine();






List<int> points = new List<int> { 0, 1, 2 };

(from a in points
 from b in points
 select (a + "," + b))
.ToList()
.ForEach(Console.WriteLine);
Console.WriteLine();







string LapTime = "00:45,01:32,02:18,03:01,03:44,04:31,05:19,06:01,06:47,07:35";
var laptime = (from time in LapTime.Split(',')
               select TimeSpan.ParseExact(time, "m\\:ss", CultureInfo.InvariantCulture)
              .TotalSeconds).ToList();


List<double> lap = new List<double>();
for (int i = 0; i < laptime.Count; i++)
{

    double a = laptime.ElementAt(i) -
        (i == 0 ? 0 : laptime.ElementAt(i - 1));
    lap.Add(a);

}
foreach (double a in lap) { Console.WriteLine(a); }
Console.WriteLine();


//var laptime = (from time in LapTime.Split(',')
//               select TimeSpan.ParseExact(time, "m\\:ss", CultureInfo.InvariantCulture)
//              .TotalSeconds).ToList();

//.ForEach((a,Index)=>a.ElementAt[Index]-(Index == 0 ? 0 : a.ElementAt(Index - 1)))

//let t = Enumerable.Range(0, LapTime.Split(',').Count() - 1)
//let a = TimeSpan.ParseExact(LapTime.Split(','), "m\\:ss", CultureInfo.InvariantCulture).TotalSeconds
//let y = a.ElementAt[t] - (t == 0 ? 0 : a.ElementAt(t - 1));

//var z = LapTime.Split(',').Zip(LapTime.Split(','), (a, b) => (TimeSpan.ParseExact(a, "m\\:ss", CultureInfo.InvariantCulture) -
//                                                             TimeSpan.ParseExact(b, "m\\:ss", CultureInfo.InvariantCulture)).TotalSeconds);
//Console.WriteLine(z);

string times = "00:45,01:32,02:18,03:01,03:44,04:31,05:19,06:01,06:47,07:35";

//var result = (times.Split(',')
//            .Zip(times.Split(','), (Current, Next) => (Current + " " +
//            ((TimeSpan.ParseExact(Next, "m\\:ss", System.Globalization.CultureInfo.InvariantCulture)).TotalSeconds -
//            (TimeSpan.ParseExact(Current, "m\\:ss", System.Globalization.CultureInfo.InvariantCulture)).TotalSeconds)))).ToList();

// from time in times
// let a = time.ToString()
// let b = (TimeSpan.ParseExact(a.Split(','), "m\\:ss", System.Globalization.CultureInfo.InvariantCulture).TotalSeconds
// let b2 = (b.insert(0,"0:00")).zip(b, (Current, Next))=> (Current + " " + (Current - Next)).ToList 



var time3 = times.Insert(0, "0:00,").Split(',')
           .Zip(times.Split(','), (Current, Next) => (
            ((TimeSpan.ParseExact(Next, "m\\:ss", System.Globalization.CultureInfo.InvariantCulture)).TotalSeconds -
            (TimeSpan.ParseExact(Current, "m\\:ss", System.Globalization.CultureInfo.InvariantCulture)).TotalSeconds)));




foreach (var z in time3) { Console.WriteLine(z); };

//string Numbers = "2,5,7-10,11,17-18";

//from num in Numbers.Split(',')

//let rangeSplit = num.Split('-')

//let start = int.Parse(rangeSplit[0])

//let end = int.Parse(rangeSplit[1])

//let result = int.Parse(rangeSplit).AddRange(start)

//Take the following string "2,5,7-10,11,17-18" and turn it into an IEnumerable of integers: 2 5 7 8 9 10 11 17 18

//from al in alphabet

//var alphabet = "abcdefghijklmnopqrstuvwxyz !";

//var num = new Dictionary<string, int>();

//var numm2 = dict[alphabet]


//var message = "23,5,12,12,27,4,15,14,5,28";
//foreach (var num in message)
//{

//}


//var names = new string[] { "Sam", "Joe", "Mary", "Edith", "Sybill", "Cora",
//"Laura", "Dave", "Andy", "Shaun", "Joe", "Bob", "Keith", "Partario", "Rachel",
//"Jacci", "Lucy", "Andy", "Sam", "Emma", "Henry", "Nafisa", "Henry", "Joe" };
//var existingNames = new List<string> { "John", "Keith", "Phil", "Tom", "Joe", "Bob", "Keith", "Partario", };


////allnames(names, existingNames).ForEach(Console.WriteLine);
////DistinctNames(names, existingNames).ForEach(Console.WriteLine);
////DuplicateNames(names, existingNames);
//foreach (var name in DuplicateNames(names, existingNames)) { Console.WriteLine(name); }
//Console.WriteLine( CountDuplicate(names, existingNames));  

//List<string> allnames(string[] name, List<string> existingName)
//{
//    var list =new List<string>();
//    list.AddRange(name);
//    list.AddRange(existingName);
//    return list;
//}
////foreach (var names in existingName) { Console.WriteLine(names); }
//List<string> DistinctNames(string[] name, List<string> existingName)
//{
//      var x= allnames(name, existingName).Distinct().ToList();
//    return x;
//}
//Dictionary<string,int> DuplicateNames(string[] name, List<string> existingName)
//{
//    var y = allnames(name, existingName);
//    var query = y.GroupBy(x => x)
//              .Where(g => g.Count() > 1)
//              .ToDictionary(x => x.Key, y => y.Count());
//    return query;
//}

//int CountDuplicate(string[] name, List<string> existingName)
//{

//    var y = allnames(name, existingName);
//    //var query = y.GroupBy(x => x)
//    //            .Where(g => g.Count() > 1).Count();

//   var x= y.GroupBy(x => x)
//                .Where(g => g.Count() > 1);
//                ;
//    return x;
//}

double borrow = 10310.500;
double intrest = 9.90/100.00/12; 
for(int i=0; i< 47; i++)
{
      
    borrow += borrow*intrest;
    borrow -= 258.92;
    
    
}
Console.WriteLine(borrow);