namespace CollectionsExercises
{
    class Program
    {
        static void Main(string[] args)
        {
            Exercise1();
            Exercise2();
            Exercise3();
            Exercise4();
            Exercise5();
            Exercise6();
        }

        // =============================
        // Exercise 1: Student Grade Manager
        // =============================
        static void Exercise1()
        {
            Console.WriteLine("\n===== Exercise 1 =====");

            List<int> grades = new() { 85, 92, 78, 95, 88, 70, 100, 65 };

            Console.WriteLine("Grades: " + string.Join(", ", grades));
            Console.WriteLine($"Count: {grades.Count}");
            Console.WriteLine($"First: {grades.First()}");
            Console.WriteLine($"Last: {grades.Last()}");

            grades.Sort();
            Console.WriteLine("Sorted: " + string.Join(", ", grades));

            int above90 = grades.FirstOrDefault(g => g > 90);
            Console.WriteLine($"First > 90: {above90}");

            var failing = grades.Where(g => g < 75).ToList();
            Console.WriteLine("Failing: " + string.Join(", ", failing));

            grades.RemoveAll(g => g < 75);
            Console.WriteLine("After Remove Failing: " + string.Join(", ", grades));

            Console.WriteLine($"Any 100? {grades.Any(g => g == 100)}");

            var gradeStrings = grades.Select(g => $"Grade: {g}").ToList();
            Console.WriteLine(string.Join(" | ", gradeStrings));
        }


        // =============================
        // Exercise 2: Leaderboard
        // =============================
        static void Exercise2()
        {
            Console.WriteLine("\n===== Exercise 2 =====");

            SortedList<int, string> leaderboard = new()
            {
                { 500, "Ahmed" },
                { 200, "Sara" },
                { 800, "Ali" },
                { 350, "Mona" }
            };

            foreach (var item in leaderboard)
                Console.WriteLine($"{item.Key} = {item.Value}");

            Console.WriteLine($"First Key: {leaderboard.Keys[0]}");
            Console.WriteLine($"First Value: {leaderboard.Values[0]}");

            Console.WriteLine($"Contains 500? {leaderboard.ContainsKey(500)}");

            if (leaderboard.TryGetValue(999, out string? player))
                Console.WriteLine(player);
            else
                Console.WriteLine("Score 999 not found");

            leaderboard.Remove(200);

            Console.WriteLine("After Remove:");
            foreach (var item in leaderboard)
                Console.WriteLine($"{item.Key} = {item.Value}");
        }


        // =============================
        // Exercise 3: Phone Book
        // =============================
        static void Exercise3()
        {
            Console.WriteLine("\n===== Exercise 3 =====");

            Dictionary<string, string> phoneBook = new()
            {
                { "Ahmed", "0100" },
                { "Sara", "0200" },
                { "Ali", "0300" },
                { "Mona", "0400" }
            };

            phoneBook["Ahmed"] = "9999"; // update

            try
            {
                phoneBook.Add("Ahmed", "1111");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Add Error: " + ex.Message);
            }

            bool added = phoneBook.TryAdd("Ahmed", "2222");
            Console.WriteLine($"TryAdd success? {added}");

            Console.WriteLine("Search Not Exist: " + phoneBook.ContainsKey("Omar"));

            Console.WriteLine(phoneBook.GetValueOrDefault("Omar", "Not Found"));

            Console.WriteLine("Keys: " + string.Join(", ", phoneBook.Keys));
            Console.WriteLine("Values: " + string.Join(", ", phoneBook.Values));
        }


        // =============================
        // Exercise 4: Unique Email Validator
        // =============================
        static void Exercise4()
        {
            Console.WriteLine("\n===== Exercise 4 =====");

            HashSet<string> emails = new(StringComparer.OrdinalIgnoreCase)
            {
                "ahmed@test.com",
                "AHMED@test.com",
                "sara@test.com",
                "Sara@Test.Com"
            };

            Console.WriteLine($"Count: {emails.Count}");
            Console.WriteLine("Reason: Case-insensitive so duplicates ignored");

            HashSet<int> setA = new() { 1, 2, 3, 4, 5 };
            HashSet<int> setB = new() { 4, 5, 6, 7, 8 };

            var union = new HashSet<int>(setA);
            union.UnionWith(setB);
            Console.WriteLine("Union: " + string.Join(", ", union));

            var intersect = new HashSet<int>(setA);
            intersect.IntersectWith(setB);
            Console.WriteLine("Intersect: " + string.Join(", ", intersect));

            var except = new HashSet<int>(setA);
            except.ExceptWith(setB);
            Console.WriteLine("Except: " + string.Join(", ", except));

            Console.WriteLine($"IsSubset: {new HashSet<int> { 1, 2 }.IsSubsetOf(setA)}");
        }


        // =============================
        // Exercise 5: Queue
        // =============================
        static void Exercise5()
        {
            Console.WriteLine("\n===== Exercise 5 =====");

            Queue<string> queue = new();

            queue.Enqueue("Report.pdf");
            queue.Enqueue("Invoice.pdf");
            queue.Enqueue("Letter.docx");
            queue.Enqueue("Resume.pdf");
            queue.Enqueue("Photo.jpg");

            Console.WriteLine("Queue: " + string.Join(", ", queue));
            Console.WriteLine($"Count: {queue.Count}");

            Console.WriteLine("Next: " + queue.Peek());

            while (queue.Count > 0)
            {
                Console.WriteLine("Printing: " + queue.Dequeue());
            }

            bool result = queue.TryDequeue(out string? doc);
            Console.WriteLine($"TryDequeue success? {result}");
        }


        // =============================
        // Exercise 6: Stack
        // =============================
        static void Exercise6()
        {
            Console.WriteLine("\n===== Exercise 6 =====");

            Stack<string> history = new();

            history.Push("google.com");
            history.Push("github.com");
            history.Push("stackoverflow.com");
            history.Push("youtube.com");
            history.Push("claude.ai");

            Console.WriteLine("Current: " + history.Peek());

            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine("Back from: " + history.Pop());
            }

            Console.WriteLine("Current after back: " + history.Peek());

            history.Clear();

            bool result = history.TryPop(out string? page);
            Console.WriteLine($"TryPop success? {result}");
        }
    }
}