using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace LinqSnippets
{
    public class Snippets
    {
        // Basic Search on LinQ
        static public void BasicLinQ()
        {
            string[] cars =
            {
                "VW Golf",
                "VW California",
                "Audi A3",
                "Audi A5",
                "Fiat Punto",
                "Seat Ibiza",
                "Seat Leon"
            };

            // 1. SELECT * of cars (SELECT ALL CARS)
            var carList = from car in cars select car;

            foreach (var car in carList)
            {
                Console.WriteLine(car);
            }

            // 2. SELECT WHERE car is Audi (SELECT ALL AUDIs)
            var audiList = from car in cars where car.Contains("Audi") select car;

            foreach (var audi in audiList) 
            { 
                Console.WriteLine(audi); 
            }

        }

        // Number Examples
        static public void LinqNumbers()
        {
            List<int> numbers = new List<int> { 1, 2, 3, 4, 5, 6, 8, 9 };

            // Each Number multiplied by 3
            // Take all numbers, but not 9
            // Order numbers by Ascending value

            var processedNumberList =
                numbers
                    .Select(num => num * 3) // Seleccionamos toda la lista, y multiplicamos por 3 todos los numeros.
                    .Where(num => num != 9) // Que lo aplique a todos menos al 9
                    .OrderBy(num => num);   // Y que lo ordene por orden ascendenete basandose en el num. 
        }

        // Medium-Advanced Search with LinQ
        static public void SearchExamples()
        {
            List<string> textList = new List<string>
            {
                "a",
                "bx",
                "c",
                "d",
                "e",
                "cj",
                "f",
                "c"
            };

            // 1. First of all elements
            var first = textList.First();

            // 2. First element that is "c"
            var cText = textList.First(text => text.Equals("c"));

            // 3. First element that contains "j"
            var jText = textList.First(text => text.Contains("j"));

            // 4. First element that contains "z" or default
            var firstOrDefaultText = textList.FirstOrDefault(text => text.Contains("z")); // Si no encuentra ningun elemento con la "z" nos devuelve una lista vacia. 

            // 5. Last element that contains "z" or default
            var lstOrDefaultText = textList.LastOrDefault(text => text.Contains("z"));

            // 6. Single Values
            var uniqueTexts = textList.Single(); // Devuelve una lista con los elementos, obviando los ya listados o repetidos. 
            var uniqueOrDefaultTexts = textList.SingleOrDefault();

       
            int[] evenNumbers = { 0, 2, 4, 6, 8 };
            int[] otherEvenNumbers = { 0, 2, 6 };

            // 7. Obtain { 4, 8 }
            var myEvenNumbers = evenNumbers.Except(otherEvenNumbers); // El resultado sera 4 y 8 ya que elimina todos los resultados que esten en ambas listas. 
        }

        // Select Multiple elements
        static public void MultipleSelects()
        {
            // 1. SELECT MANY
            string[] myOpinions =
            {
                "Opinion 1, Text 1",
                "Opinion 2, Text 2",
                "Opinion 3, Text 3"
            };

            var myOpinionSelection = myOpinions.SelectMany(opinion => opinion.Split(",")); // Seperamos la lista por las comas y la metemos dentro de la variable.

            //================================================

            var enterprises = new[]
            {
                new Enterprise()
                {
                    Id = 1,
                    Name = "Enterprise 1",
                    Employees = new[]
                    {
                        new Employee
                        {
                            Id=1,
                            Name="Samu",
                            Email="samu@clases.com",
                            Salary=3000
                        },
                        new Employee
                        {
                            Id=2,
                            Name="Pepe",
                            Email="pepe@clases.com",
                            Salary=1000
                        },
                        new Employee
                        {
                            Id=3,
                            Name="Juanjo",
                            Email="Juanjo@clases.com",
                            Salary=4000
                        }
                    }
                },
                new Enterprise()
                {
                    Id = 2,
                    Name = "Enterprise 2",
                    Employees = new[]
                    {
                        new Employee
                        {
                            Id=4,
                            Name="Ana",
                            Email="Ana@clases.com",
                            Salary=3000
                        },
                        new Employee
                        {
                            Id=5,
                            Name="Maria",
                            Email="Maria@clases.com",
                            Salary=1500
                        },
                        new Employee
                        {
                            Id=6,
                            Name="Marta",
                            Email="Marta@clases.com",
                            Salary=6000
                        }
                    }
                }
            };

            // 2. Obtain all Employees of all Enterprises
            var employeeList = enterprises.SelectMany(enterprise => enterprise.Employees);

            // Know if any list is empty
            bool hasEnterprises = enterprises.Any(); // Nos devuelve la respuesta en bool si tiene algo o no dentro de la lista, donde sea.

            bool hasEmployees = enterprises.Any(enterprise => enterprise.Employees.Any()); // Todas las empresas tienen que tener al menos 1 empleado creado.

            // All enterprises at least has an employee with at least 1000$ of salary
            bool hasEmployeeWithSalaryMoreThanOrEqual1000 = 
                enterprises.Any(enterprise => 
                    enterprise.Employees.Any(employee => employee.Salary >= 1000));
        }

        // Trabajando con colecciones
        static public void linqCollections()
        {
            var firstList = new List<string>() { "a", "b", "c" };
            var secondList = new List<string>() { "a", "c", "d" };

            // INNER JOIN
            // Forma clasica y literal
            var commonResult = from element in firstList                // Guardamos los elementos dentro de las variables element y secondElement
                               join secondElement in secondList         // Guardamos los elementos dentro de las variables element y secondElement
                               on element equals secondElement          // Obtenemos todos los elementos que son iguales entre ambas listas
                               select new { element, secondElement };   // Creame una lista con los resultados compartidos. 

            // Otra forma mas atipica, pero funcional
            var commonResult2 = firstList.Join(
                    secondList,
                    element => element,
                    secondElement => secondElement,
                    (element, secondElement) => new { element, secondElement }
                );

            // OUTTER JOIN - LEFT (Todos los elementos de la lista de la izquierda que no esten compartidos o en la lista de la derecha)
            var leftOuterJoin = from element in firstList                               // Guardamos los elementos dentro de las variables element y secondElement
                                join secondElement in secondList                        // Guardamos los elementos dentro de las variables element y secondElement
                                on element equals secondElement                         // Seleccionamos todo lo que es comun en las dos listas
                                into temporalList                                       // Guardamos el resultado en una lista temporal
                                from temporalElement in temporalList.DefaultIfEmpty()   // de la lista temporal, sacame todos los elementos y metelos en la variable temporalElement
                                where element != temporalElement                        // Selecciona todo lo que este dentro de element que sea diferente a lo que esta dentro de los elementos temporales
                                select new { Element = element };                       // Esos resultados metelos en la lista. 

            // Version corta
            var leftOutterJoin2 = from element in firstList
                                    from secondElement in secondList.Where(s => s == element).DefaultIfEmpty()
                                    select new {Element = element, SecondElement = secondElement }; 

            // OUTTER JOIN - RIGHT
            var rightOuterJoin = from secondElement in secondList                       
                                 join element in firstList                              
                                 on secondElement equals element                         
                                 into temporalList                                       
                                 from temporalElement in temporalList.DefaultIfEmpty()   
                                 where secondElement != temporalElement                  
                                 select new { Element = secondElement };         
            
            // UNION - Unimos todos los elementos de ambas listas que no se repiten entre si
            var unionList = leftOuterJoin.Union(rightOuterJoin);    
        }

        // SKIP or TAKE
        static public void SkipTakeLinq()
        {
            var myList = new[]
            {
                1,2,3,4,5,6,7,8,9,10
            };

            //SKIP
            var skipTwoFirstValues = myList.Skip(2); // { 3,4,5,6,7,8,9,10 }

            var skipLastTwoValues = myList.SkipLast(2); // { 1,2,3,4,5,6,7,8 }

            var skipWhile = myList.SkipWhile(num => num < 4); // { 5,6,7,8,9,10 }

            // TAKE
            var takeFirstTwoValues = myList.Take(2); // { 1,2 }

            var takeLastTwoValues = myList.TakeLast(2); // { 9,10 }

            var takeWhileSmallerThan4 = myList.TakeWhile(num => num < 4); // { 1,2,3 }
        }


        // Paging - El paging es la posibilidad de colocar 10 elementos de una busqueda en la pagina 1, los 10 siguientes en la pagina 2, y asi sucesivamente.
        public IEnumerable<T> GetPage<T>(IEnumerable<T> collection, int pageNumber, int resultsPerPage)
        {
            int startIndex = (pageNumber - 1) * resultsPerPage;
            return collection.Skip(startIndex).Take(resultsPerPage);
        }

        // LinQ variables
        static public void LinqVariables()
        {
            int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            var aboveAverage = from number in numbers
                               let average = numbers.Average()
                               let nSquare = Math.Pow(number, 2)
                               where nSquare > average
                               select number;

            Console.WriteLine($"Average: {numbers.Average()}");
            foreach (int number in aboveAverage)
            {
                Console.WriteLine($"Query: Number: {number} Square: {Math.Pow(number, 2)}");
            }
        }

        // ZIP - Es una cremallera entre dos listas, coe el valor 1 de la lista 1, valor 1 de la lista 2, valor 2 de la lista 1, valor 2 de la lista 2, y asi sucesibamente. 
        static public void ZipLinq()
        {
            int[] numbers = { 1, 2, 3, 4, 5 };
            string[] stringNumbers = { "one", "two", "three", "four", "five" };

            IEnumerable<string> zipNumbers = numbers.Zip(stringNumbers, (number, word) => $"{number} = {word}");
            // { "1=one", "2=two", ... } 
        }

        // Repear & Range - Range y repeat son metodos que tienen los Enumerables que se pueden utilizar dentro de LinQ. Se utilizan para generar secuencias simples. 
        static public void repeatRangeLinq()
        {
            // Generate collection from 1 - 1000
            var first1000 = Enumerable.Range(1, 1000);

            // Repear a value N times
            IEnumerable<string> fiveXs = Enumerable.Repeat("X", 5); // { "X", "X", "X", "X", "X" }
        }

        static public void studentsLinq()
        {
            var classRoom = new[]
            {
                new Student
                {
                    Id = 1,
                    Name = "Samuel",
                    Grade = 90,
                    Certified = true,
                },
                new Student
                {
                    Id = 2,
                    Name = "Juan",
                    Grade = 40,
                    Certified = false,
                },
                new Student
                {
                    Id = 3,
                    Name = "Ana",
                    Grade = 96,
                    Certified = true,
                },
                new Student
                {
                    Id = 4,
                    Name = "Antonio",
                    Grade = 10,
                    Certified = false,
                },
                new Student
                {
                    Id = 5,
                    Name = "Fermin",
                    Grade = 50,
                    Certified = true,
                },
            };

            var certifiedStudents = from student in classRoom
                                    where student.Certified
                                    select student;

            var notCertifiedStudent = from student in classRoom
                                      where student.Certified == false
                                      select student;

            var approvedStudentsName = from student in classRoom
                                       where student.Grade >= 50 && student.Certified == true
                                       select student.Name;
        }

        // ALL - En este caso analiza TODOS los campos y nos da la respuesta, en diferencia al ANY que es cualquiera, ALL es todos. 
        static public void allLinq()
        {
            var numbers = new List<int>() { 1, 2, 3, 4, 5, 6 };
            bool allAreSmallerThan10 = numbers.All(x => x < 10); // true
            bool allAreBiggerOrEqualThan2 = numbers.All(x => x >= 2); // False

            var emptyList = new List<int>();
            bool allNumbersAreGreaterThan0 = emptyList.All(x => x >= 0); // true - ALL lo que hace es parar la iteracion por cada uno de los valores en cuanto encuentra un elemento que no cumple la especificacion que le estamos especificando.
                                                                         //            En este caso no llega a iterar porque esta vacia, y da un falso positivo.  
        }

        // Aggregate - Un agregado es una secuencia acumulativa de funciones, una detras de otra. Realizar operaciones cuya previa salida es la entrada de la siguiente funcion. 
        static public void aggregateQueries()
        {
            int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            // Summ all numbers
            int sum = numbers.Aggregate((prevSum, current) => prevSum + current); // 55

            // 0, 1 => 1
            // 1, 2 => 3
            // 3, 3 => 6
            // 6, 4 => 10
            // etc.

            string[] words = { "hello, ", "my ", "name ", "is ", "Samuel" };
            string greeting = words.Aggregate((prevGreeting, current) => prevGreeting + current); // hello, my name is Samuel

            // "" + "hello, " = hello,
            // "hello, " + "my " = hello, my
            // "hello, my" + "name " = hello, my name
            // etc.
        }

        //Distinct - Nos permite crear una lista IEnum a partir de otra lista donde los valores repetidos se ignoran.
        static public void distincValues()
        {
            int[] numbers = { 1, 2, 3, 4, 5, 5, 4, 3, 2, 1 };

            IEnumerable<int> distinctValues = numbers.Distinct(); 
        }

        // GroupBy - Nos permite hacer agrupaciones por algun tipo de condicion, pares o impares por ejemplo. 
        public static void groupByExamples()
        {
            List<int> numbers = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            // Obtain only even numbers and generate two groups
            var grouped = numbers.GroupBy(x => x % 2 == 0);

            // We will have two groups:
            // 1. The group that doesn't fit the condition (odd numbers)
            // 2. The group that fits the condition (even numbers)

            foreach (var group in grouped)
            {
                foreach (var value in group)
                {
                    Console.WriteLine(value); // 1,3,5,7,9 ... 2,4,6,8 (first the odds and then the even
                }
            }

            // Another Example
            var classRoom = new[]
            {
                new Student
                {
                    Id = 1,
                    Name = "Samuel",
                    Grade = 90,
                    Certified = true
                },
                new Student
                {
                    Id = 2,
                    Name = "Juan",
                    Grade = 40,
                    Certified = false
                },
                new Student
                {
                    Id = 3,
                    Name = "Ana",
                    Grade = 96,
                    Certified = true
                },
                new Student
                {
                    Id = 4,
                    Name = "Antonio",
                    Grade = 10,
                    Certified = false
                },
                new Student
                {
                    Id = 5,
                    Name = "Fermin",
                    Grade = 50,
                    Certified = true
                }
            };

            var certifiedQuery = classRoom.GroupBy(student => student.Certified);

            // We obtain two groups
            // 1. Not certified students
            // 2. Certified students

            foreach (var group in certifiedQuery)
            {
                Console.WriteLine($"---------- { group.Key } ----------");
                foreach (var student in group)
                {
                    Console.WriteLine(student.Name); 
                }
            }
        }

        // Relation LinQ
        static public void relationsLinq()
        {
            List<Post> posts = new List<Post>()
            {
                new Post()
                {
                    Id = 1,
                    Title = "My First Post",
                    Content = "My first Content:",
                    Created = DateTime.Now,
                    Comments = new List<Comment>()
                    {
                        new Comment()
                        {
                            Id = 1,
                            Created = DateTime.Now,
                            Title = "My first Comment",
                            Content = "My content"

                        },
                        new Comment()
                        {
                            Id = 2,
                            Created = DateTime.Now,
                            Title = "My second Comment",
                            Content = "My other content"

                        }
                    }
                },
                new Post()
                {
                    Id = 2,
                    Title = "My second Post",
                    Content = "My second Content:",
                    Created = DateTime.Now,
                    Comments = new List<Comment>()
                    {
                        new Comment()
                        {
                            Id = 3,
                            Created = DateTime.Now,
                            Title = "My other Comment",
                            Content = "My content"

                        },
                        new Comment()
                        {
                            Id = 4,
                            Created = DateTime.Now,
                            Title = "My other of other Comment",
                            Content = "My other content"

                        }
                    }
                }
            };

            // Get all comments of a post
            var commentsContent = posts.SelectMany(
                post => post.Comments, 
                (post, comment) => new { PostId = post.Id, CommentContent = comment.Content });
        }
    }
}