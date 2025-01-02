using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeteTech
{
    public class DataPoints
    {
        private readonly string folderPath = @"C:\PeteData";
        private readonly string filePath = Path.Combine(@"C:\PeteData", "PeteData.txt");
       

        public int DataPoint1 { get; set; }
        public int DataPoint2 { get; set; }
        public int DataPoint3 { get; set; }
        public int DataPoint4 { get; set; }
        public int DataPoint5 { get; set; }
        public TimeSpan Duration27K { get; set; }
        public TimeSpan Duration3074 { get; set; }
        public TimeSpan Duration7500 { get; set; }


        public DataPoints()
        {
            filePath = Path.Combine(folderPath, "PeteData.txt");
            LoadDataPoints();
        }

        public void LoadDataPoints()
        {
            try
            {
                if (File.Exists(filePath))
                {
                    string[] lines = File.ReadAllLines(filePath);
                    if (lines.Length >= 7)
                    {
                        DataPoint1 = int.Parse(lines[0]);
                        DataPoint2 = int.Parse(lines[1]);
                        DataPoint3 = int.Parse(lines[2]);
                        DataPoint4 = int.Parse(lines[3]);
                        DataPoint5 = int.Parse(lines[4]);
                        Duration27K = TimeSpan.Parse(lines[5]);
                        Duration3074 = TimeSpan.Parse(lines[6]);
                        Duration7500 = TimeSpan.Parse(lines[7]);
                    }
                    Console.WriteLine("Data points loaded successfully.");
                }
                else
                {
                    Console.WriteLine("File does not exist.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while loading data points: {ex.Message}");
            }
        }

        public void SaveDataPoints()
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(filePath))
                {
                    writer.WriteLine(DataPoint1);
                    writer.WriteLine(DataPoint2);
                    writer.WriteLine(DataPoint3);
                    writer.WriteLine(DataPoint4);
                    writer.WriteLine(DataPoint5);
                    writer.WriteLine(Duration27K);
                    writer.WriteLine(Duration3074);
                    writer.WriteLine(Duration7500);
                }
                Console.WriteLine("Data points saved successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while saving data points: {ex.Message}");
            }
        }

        public void CreateFolderAndFile()
        {
            try
            {
                // Check if the folder exists, if not, create it
                if (!Directory.Exists(folderPath))
                {
                    Directory.CreateDirectory(folderPath);
                    Console.WriteLine("Folder created successfully.");
                }

                // Check if the file exists, if not, create it
                if (!File.Exists(filePath))
                {
                    using (FileStream fs = File.Create(filePath))
                    {
                        // Initialize data points to zero
                        DataPoint1 = 0;
                        DataPoint2 = 0;
                        DataPoint3 = 0;
                        DataPoint4 = 0;
                        DataPoint5 = 0;
                        Duration27K = TimeSpan.Zero;
                        Duration3074 = TimeSpan.Zero;
                        Duration7500 = TimeSpan.Zero;

                        // Save the initialized data points to the file
                        SaveDataPoints();
                    }
                    Console.WriteLine("File created successfully.");
                }
                else
                {
                    Console.WriteLine("File already exists.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }

        public void SetDataPoint(int index, int value)
        {
            switch (index)
            {
                case 1:
                    DataPoint1 = value;
                    break;
                case 2:
                    DataPoint2 = value;
                    break;
                case 3:
                    DataPoint3 = value;
                    break;
                case 4:
                    DataPoint4 = value;
                    break;
                case 5:
                    DataPoint5 = value;
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(index), "Index must be between 1 and 5.");
            }
        }

        

        public void UpdateDataPoint(int index, int increment)
        {
            // Load the current data points from the file
            LoadDataPoints();

            // Update the specified data point
            int currentValue = GetDataPoint(index);
            SetDataPoint(index, currentValue + increment);

            

            // Save the updated data points back to the file
            SaveDataPoints();
        }

        public int GetDataPoint(int index)
        {
            return index switch
            {
                1 => DataPoint1,
                2 => DataPoint2,
                3 => DataPoint3,
                4 => DataPoint4,
                5 => DataPoint5,
                _ => throw new ArgumentOutOfRangeException(nameof(index), "Index must be between 1 and 5."),
            };
        }

        public void SetDuration27K(TimeSpan duration)
        {
            
            Duration27K += duration;
            
        }

        public void SetDuration3074(TimeSpan duration)
        {
           
            Duration3074 += duration;
            
        }

        public void SetDuration7500(TimeSpan duration)
        {

            Duration7500 += duration;

        }
    }
}
