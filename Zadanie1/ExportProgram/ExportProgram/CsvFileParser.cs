using ExportProgram.Error;
using ExportProgram.Model;
using ExportProgram.Students;

namespace ExportProgram
{
    public class CsvFileParser
    {
        public ExportedData ParseCsv(string filepath, ExportedData document)
        {
            
            try
            {
                FileInfo fileInfo = new(filepath);
                using (StreamReader stream = new(fileInfo.OpenRead()))
                {
                    string? line = null;
                    int lineNumber = 0;
                    while ((line = stream.ReadLine()) != null)
                    {
                        lineNumber++;
                        try
                        {
                            document.University.AddStudent(ParseStudent(line));
                        }
                        catch (MissingStudentDataException e)
                        {
                            _ = LogWriter.WriteToLogFile(e.Message.ToString() + ": Pominięto studenta o niepełnych danych (linia " + lineNumber + "): " + line);
                            Console.WriteLine(e.Message + ", linia " + lineNumber);
                            continue;
                        }
                    }     
                }
            } catch(DirectoryNotFoundException e)
            {
                _ = LogWriter.WriteToLogFile(e.Message.ToString());
                throw new ArgumentException("Podana ścieżka jest niepoprawna");
            } catch(FileNotFoundException e)
            {
                _ = LogWriter.WriteToLogFile(e.Message.ToString());
                throw new FileNotFoundException("Podany plik nie istnieje");
            }

            return document;
        }

        private static Student ParseStudent(string line)
        {
            string[] arr = line.Split(',');

            if (arr.Length != 9)
            {
                throw new MissingStudentDataException("Nieprawidłowe dane u studenta");
            }

            for (int i = 0; i < arr.Length; i++)
            {
                if (String.IsNullOrEmpty(arr[i]))
                {
                    throw new MissingStudentDataException("Brakujące dane u studenta");

                }
            }

            Studies studies = new(arr[2], arr[3]);
            Student st = new()
            {
                FName = arr[0],
                LName = arr[1],
                Studies = studies,
                IndexNumber = arr[4],
                DateBirth = arr[5],
                Email = arr[6],
                MothersName = arr[7],
                FathersName = arr[8]
            };

            return st;
        }
    }
}
