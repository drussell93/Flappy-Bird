using System;
using System.IO; 
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FlappyBird
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new GameWindow());


            // LINQ to sort scores 
            var projectFolder = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;
            var file = Path.Combine(projectFolder, @"Game\Data\Scores.txt");
            var highScores = Path.Combine(projectFolder, @"Game\Data\HighScores.txt");

            string[] scores = File.ReadAllLines(file);

            var scoreQuery = (from line in scores
                         let fields = line.Split(':')
                         orderby fields[1] descending
                         select line).Take(5);

            File.Delete(highScores);
            foreach (var line in scoreQuery)
            {
                File.AppendAllText(highScores, line + Environment.NewLine);
            }
        }
    }
}
