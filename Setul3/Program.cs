///Pecherle George-Daniel 12_09_2022
using System;
using System.Collections.Immutable;
using System.ComponentModel;
using System.Globalization;
using System.Numerics;
using System.Reflection.Metadata;
using System.Text.RegularExpressions;

namespace Set3
{
    class Program
    {
        private static Random rnd = new Random();
        private static List<string> instructions = new List<string>()
        {
            "Acesta este lista cu instructiuni pentru setul 3:" ,
            "Calculati suma elementelor unui vector de n numere citite de la tastatura. Rezultatul se va afisa pe ecran.",
            "Se da un vector cu n elemente si o valoare k. Se cere sa se determine prima pozitie din vector pe care apare k. Daca k nu apare in vector rezultatul va fi -1.",
            "Sa se determine pozitiile dintr-un vector pe care apar cel mai mic si cel mai mare element al vectorului. Pentru extra-credit realizati programul efectuand 3n/2 comparatii (in cel mai rau caz).",
            "Deteminati printr-o singura parcurgere, cea mai mica si cea mai mare valoare dintr-un vector si de cate ori apar acestea.",
            "Se da un vector cu n elemente, o valoare e si o pozitie din vector k. Se cere sa se insereze valoarea e in vector pe pozitia k. Primul element al vectorului se considera pe pozitia zero.",
            "Se da un vector cu n elemente si o pozitie din vector k. Se cere sa se stearga din vector elementul de pe pozitia k. Prin stergerea unui element, toate elementele din dreapta lui se muta cu o pozitie spre stanga.",
            "Reverse. Se da un vector nu n elemente. Se cere sa se inverseze ordinea elementelor din vector. Prin inversare se intelege ca primul element devine ultimul, al doilea devine penultimul etc.",
            "Rotire. Se da un vector cu n elemente. Rotiti elementele vectorului cu o pozitie spre stanga. Prin rotire spre stanga primul element devine ultimul, al doilea devine primul etc.",
            "Rotire k. Se da un vector cu n elemente. Rotiti elementele vectorului cu k pozitii spre stanga.",
            "Cautare binara. Se da un vector cu n elemente sortat in ordine crescatoare. Se cere sa se determine pozitia unui element dat k. Daca elementul nu se gaseste in vector rezultatul va fi -1.",
            "Se da un numar natural n. Se cere sa se afiseze toate numerele prime mai mici sau egale cu n (ciurul lui Eratostene).",
            "Sortare selectie. Implementati algoritmul de sortare <Selection Sort>.",
            "Sortare prin insertie. Implementati algoritmul de sortare <Insertion Sort>.",
            "Interschimbati elementele unui vector in asa fel incat la final toate valorile egale cu zero sa ajunga la sfarsit. (nu se vor folosi vectori suplimentari - operatia se va realiza inplace cu un algoritm eficient - se va face o singura parcugere a vectorului).",
            "Modificati un vector prin eliminarea elementelor care se repeta, fara a folosi un alt vector.",
            "Se da un vector de n numere naturale. Determinati cel mai mare divizor comun al elementelor vectorului.",
            "Se da un numar n in baza 10 si un numar b. 1 < b < 17. Sa se converteasca si sa se afiseze numarul n in baza b.",
            "Se da un polinom de grad n ai carui coeficienti sunt stocati intr-un vector. Cel mai putin semnificativ coeficient este pe pozitia zero in vector. Se cere valoarea polinomului intr-un punct x.",
            "Se da un vector s (vectorul in care se cauta) si un vector p (vectorul care se cauta). Determinati de cate ori apare p in s. De ex. Daca s = [1,2,1,2,1,3,1,2,1] si p = [1,2,1] atunci p apare in s de 3 ori. (Problema este dificila doar daca o rezolvati cu un algoritm liniar).",
            "Se dau doua siraguri de margele formate din margele albe si negre, notate s1, respectiv s2. Determinati numarul de suprapuneri (margea cu margea) a unui sirag peste celalalt astfel incat margelele suprapuse au aceeasi culoare. Siragurile de margele se pot roti atunci cand le suprapunem.",
            "Se dau doi vectori. Se cere sa se determine ordinea lor lexicografica (care ar trebui sa apara primul in dictionar).",
            "Se dau doi vectori v1 si v2. Se cere sa determine intersectia, reuniunea, si diferentele v1-v2 si v2 -v1 (implementarea operatiilor cu multimi). Elementele care se repeta vor fi scrise o singura data in rezultat.",
            "Aceleasi cerinte ca si la problema anterioara dar de data asta elementele din v1 respectiv v2  sunt in ordine strict crescatoare.",
            "Aceleasi cerinte ca si la problema anterioara dar de data asta elementele sunt stocate ca vectori cu valori binare (v[i] este 1 daca i face parte din multime si este 0 in caz contrar).",
            "(Interclasare) Se dau doi vector sortati crescator v1 si v2. Construiti un al treilea vector ordonat crescator format din toate elementele din  v1 si v2. Sunt permise elemente duplicate.",
            "Se dau doua numere naturale foarte mari (cifrele unui numar foarte mare sunt stocate intr-un vector - fiecare cifra pe cate o pozitie). Se cere sa se determine suma, diferenta si produsul a doua astfel de numere.",
            "Se da un vector si un index in vectorul respectiv. Se cere sa se determine valoarea din vector care va fi pe pozitia index dupa ce vectorul este sortat.",
            "Quicksort. Sortati un vector folosind metoda QuickSort.",
            "MergeSort. Sortati un vector folosind metoda MergeSort.",
            "Sortare bicriteriala. Se dau doi vectori de numere intregi E si W, unde E[i] este un numar iar W[i] este un numar care reprezinta ponderea lui E[i]. Sortati vectorii astfel incat elementele lui E sa fie in in ordine crescatoare iar pentru doua valori egale din E, cea cu pondere mai mare va fi prima.",
            "(Element majoritate). Intr-un vector cu n elemente, un element m este element majoritate daca mai mult de n/2 din valorile vectorului sunt egale cu m (prin urmare, daca un vector are element majoritate acesta este unui singur).  Sa se determine elementul majoritate al unui vector (daca nu exista atunci se va afisa <nu exista>). (incercati sa gasiti o solutie liniara)."
        };
        private static void Main(String[] args)
        {
            int pbNumber = 0;
            foreach (string instruction in instructions)
            {
                if (pbNumber > 0)
                    Console.Write($"{pbNumber}: ");
                Console.WriteLine(instruction);
                pbNumber++;
            }
            Console.WriteLine();

            bool stop = false;
            while (!stop)
            {
                Console.Write("Dati numarul problemei pe care doriti sa o accesati(sau \"stop\" pentru oprire): ");
                string array = Console.ReadLine();
                if (array.CompareTo("stop") == 0)
                    stop = true;
                else
                {
                    try
                    {
                        Solve(Convert.ToInt32(array));
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                }
            }
        }

        /// <summary>
        /// solve the n-th exercise 
        /// </summary>
        /// <param name="n"></param>
        private static void Solve(int n)
        {
            switch (n)
            {
                case 1: P1(); break;
                case 2: P2(); break;
                case 3: P3(); break;
                case 4: P4(); break;
                case 5: P5(); break;
                case 6: P6(); break;
                case 7: P7(); break;
                case 8: P8(); break;
                case 9: P9(); break;
                case 10: P10(); break;
                case 11: P11(); break;
                case 12: P12(); break;
                case 13: P13(); break;
                case 14: P14(); break;
                case 15: P15(); break;
                case 16: P16(); break;
                case 17: P17(); break;
                case 18: P18(); break;
                case 19: P19(); break;
                case 20: P20(); break;
                case 21: P21(); break;
                case 22: P22(); break;
                case 23: P23(); break;
                case 24: P24(); break;
                case 25: P25(); break;
                case 26: P26(); break;
                case 27: P27(); break;
                case 28: P28(); break;
                case 29: P29(); break;
                case 30: P30(); break;
                case 31: P31(); break;
                default: Console.WriteLine($"Problema cu numarul {n} nu exista :("); break;
            }
        }

        /// <summary>
        /// reads N and N integers, then returns an int type array
        /// </summary>
        /// <returns></returns>
        private static int[] ReadArray()
        {
            //basic reading
            Console.Write("Dati n, dupa care dati cele n numere pe linia urmatoare: ");
            int n = Convert.ToInt32(Console.ReadLine());

            char[] separators = { ' ', ',', ':', ';' };
            string[] line = Console.ReadLine().Split(separators, StringSplitOptions.RemoveEmptyEntries);
            int[] intsLine = Array.ConvertAll(line, int.Parse);
            return intsLine;
        }
        /// <summary>
        /// overloaded function which customize the console text for a given string variable name
        /// </summary>
        /// <returns></returns>
        private static int[] ReadArray(string name)
        {
            //basic reading
            Console.Write($"Dati {name}, dupa care dati cele {name} numere pe linia urmatoare: ");
            int n = Convert.ToInt32(Console.ReadLine());

            char[] separators = { ' ', ',', ':', ';' };
            string[] line = Console.ReadLine().Split(separators, StringSplitOptions.RemoveEmptyEntries);
            int[] intsLine = Array.ConvertAll(line, int.Parse);
            return intsLine;
        }
        /// <summary>
        /// Calculati suma elementelor unui vector de n numere citite de la tastatura.Rezultatul se va afisa pe ecran.
        /// </summary>
        static void P1()
        {
            Console.WriteLine(instructions[1]);
            var array = ReadArray();
            Console.WriteLine($"Suma numerelor din vector este {array.Sum()}");
        }
        /// <summary>
        /// Se da un vector cu n elemente si o valoare k. Se cere sa se determine prima pozitie din vector pe care apare k. Daca k nu apare in vector rezultatul va fi -1. 
        /// </summary>
        static void P2()
        {
            Console.WriteLine(instructions[2]);
            Console.Write("Dati k:");
            int k = int.Parse(Console.ReadLine());
            var array = ReadArray();
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == k)
                {
                    Console.WriteLine($"Prima pozitie pe care apare {k} in vector este {i}");
                    return;
                }
            }
            Console.WriteLine($"{k} nu apare in secventa: {String.Join(" ", array)}");
        }

        /// <summary>
        /// Sa se determine pozitiile dintr-un vector pe care apar cel mai mic si cel mai mare element al vectorului. Pentru extra-credit realizati programul efectuand 3n/2 comparatii (in cel mai rau caz).
        /// </summary>
        static void P3()
        {
            Console.WriteLine(instructions[3]);
            var array = ReadArray();
            Console.WriteLine($"Pozitia minimului este {Array.IndexOf(array, array.Min())}, pozitia maximului este {Array.IndexOf(array, array.Max())}");
        }

        /// <summary>
        /// Deteminati printr-o singura parcurgere, cea mai mica si cea mai mare valoare dintr-un vector si de cate ori apar acestea. 
        /// </summary>
        static void P4()
        {
            Console.WriteLine(instructions[4]);
            var array = ReadArray();
            int minVal = int.MaxValue, maxVal = int.MinValue, cntMin = 0, cntMax = 0;
            foreach (var el in array)
            {
                if (el > maxVal)
                {
                    maxVal = el;
                    cntMax = 1;
                }
                else if (el == maxVal) cntMax++;
                if (el < minVal)
                {
                    minVal = el;
                    cntMin = 1;
                }
                else if (el == minVal) cntMin++;
            }
            Console.WriteLine($"Minimul din vector e {minVal} si apare de {cntMin} ori\nMaximul este {maxVal} si apare de {cntMax} ori");
        }

        /// <summary>
        /// Se da un vector cu n elemente, o valoare e si o pozitie din vector k. Se cere sa se insereze valoarea e in vector pe pozitia k. Primul element al vectorului se considera pe pozitia zero.
        /// </summary>
        static void P5()
        {
            Console.WriteLine(instructions[5]);
            var list = ReadArray().ToList();
            Console.Write($"Dati valoarea e pe care doriti sa o inserati si pozitia k unde doriti sa o inserati(0<=k<={list.Count - 1}): ");
            var inputs = Console.ReadLine().Split(' ');
            int e = int.Parse(inputs[0]);
            int k = int.Parse(inputs[1]);

            list.Add(list.Last()); //dubleaza ultimul element din vector
            for (int i = list.Count - 1; i > k; i--)//muta toate elementele de dupa k cu o pozitie spre dreapta pentru a-i face loc noului element
                list[i] = list[i - 1];
            list[k] = e;//insereaza elementul e pe pozitia k
            Console.WriteLine($"Vectorul dupa inserare: {String.Join(" ", list)}");
        }

        /// <summary>
        /// Se da un vector cu n elemente si o pozitie din vector k. Se cere sa se stearga din vector elementul de pe pozitia k. Prin stergerea unui element, toate elementele din dreapta lui se muta cu o pozitie spre stanga. 
        /// </summary>
        static void P6()
        {
            Console.WriteLine(instructions[6]);
            var list = ReadArray().ToList();
            Console.Write($"Dati pozitia k din vector de unde vreti sa stergeti un element(0<=k<={list.Count - 1}): ");
            int k = int.Parse(Console.ReadLine());


            list.RemoveAt(k);
            Console.WriteLine($"Lista dupa eliminarea elementului de pe poz k: {String.Join(" ", list)}");
        }

        /// <summary>
        /// Reverse. Se da un vector nu n elemente. Se cere sa se inverseze ordinea elementelor din vector. Prin inversare se intelege ca primul element devine ultimul, al doilea devine penultimul etc.
        /// </summary>
        static void P7()
        {
            Console.WriteLine(instructions[7]);
            var list = ReadArray().ToList();
            list.Reverse();
            Console.WriteLine($"Lista inversata: {String.Join(" ", list)}");
        }

        /// <summary>
        /// Rotire. Se da un vector cu n elemente. Rotiti elementele vectorului cu o pozitie spre stanga. Prin rotire spre stanga primul element devine ultimul, al doilea devine primul etc.
        /// </summary>
        static void P8()
        {
            Console.WriteLine(instructions[8]);
            var list = ReadArray().ToList();
            RotateToLeft(list, 1);
            Console.WriteLine($"Lista inversata: {String.Join(" ", list)}");
        }
        /// <summary>
        /// function that execute "number" left rotations on a given list 
        /// </summary>
        /// <param name="list"></param>
        /// <param name="number"></param>
        /// <returns></returns>
        public static void RotateToLeft(List<int> list, int number)
        {
            for (int i = 0; i < number; i++)
            {
                list.Add(list[0]);
                list.RemoveAt(0);
            }
        }

        /// <summary>
        /// Rotire k. Se da un vector cu n elemente. Rotiti elementele vectorului cu k pozitii spre stanga. 
        /// </summary>
        static void P9()
        {
            Console.WriteLine(instructions[9]);
            var list = ReadArray().ToList();
            Console.Write($"Dati k (nr de rotiri la stanga asupra listei)");
            int k = int.Parse(Console.ReadLine());

            RotateToLeft(list, k);
            Console.WriteLine($"Lista inversata: {String.Join(" ", list)}");
        }

        /// <summary>
        /// Cautare binara. Se da un vector cu n elemente sortat in ordine crescatoare. Se cere sa se determine pozitia unui element dat k. Daca elementul nu se gaseste in vector rezultatul va fi -1.
        /// </summary>
        static void P10()
        {
            Console.WriteLine(instructions[10]);
            var array = ReadArray();
            Console.Write($"Dati k (elementul caruia vreti sa-i aflati pozitia din vector)");
            int k = int.Parse(Console.ReadLine());

            Array.Sort(array);
            int poz = BinarySearch(array, k, 0, array.Length - 1);

            if (poz != -1)
                Console.WriteLine($"{k} se gaseste la pozitia {poz} in vectorul {String.Join(" ", array)}");
            else
                Console.WriteLine($"{k} nu se gaseste in vectorul {String.Join(" ", array)}");
        }

        static int BinarySearch(int[] v, int x, int left, int right)
        {
            if (left < right)
            {
                int mid = left + (right - left) / 2;
                if (v[mid] == x)
                    return mid;
                else if (v[mid] > x) return BinarySearch(v, x, 0, mid - 1);
                return BinarySearch(v, x, mid + 1, right);
            }
            else
                return -1;
        }

        /// <summary>
        /// Se da un numar natural n. Se cere sa se afiseze toate numerele prime mai mici sau egale cu n (ciurul lui Eratostene).
        /// </summary>
        static void P11()
        {
            Console.WriteLine(instructions[11]);
            var array = ReadArray();
        }

        /// <summary>
        /// Sortare selectie. Implementati algoritmul de sortare <Selection Sort>. 
        /// </summary>
        static void P12()
        {
            Console.WriteLine(instructions[12]);
            var array = ReadArray();
            SelectionSort(array);
            Console.WriteLine($"Vectorul dupa sortare: {String.Join(" ", array)}");
        }

        private static void SelectionSort(int[] array)
        {
            for (int i = 0; i < array.Length - 1; i++)
            {
                int minIndex = i;
                for (int j = i + 1; j < array.Length; j++)
                    if (array[j] < array[minIndex])
                        minIndex = j;
                (array[i], array[minIndex]) = (array[minIndex], array[i]);
            }
        }

        /// <summary>
        /// Sortare prin insertie. Implementati algoritmul de sortare <Insertion Sort>.
        /// </summary>
        static void P13()
        {
            Console.WriteLine(instructions[13]);
            var array = ReadArray();
            InsertionSort(array);
            Console.WriteLine($"Vectorul dupa sortare: {String.Join(" ", array)}");
        }

        private static void InsertionSort(int[] array)
        {
            for (int i = 1; i < array.Length; i++)
            {
                int pos = i;
                int value = array[i];
                while (i > 0 && value < array[i - 1])
                    i--;
                (array[i], array[pos]) = (array[pos], array[i]);
            }
        }

        /// <summary>
        /// Interschimbati elementele unui vector in asa fel incat la final toate valorile egale cu zero sa ajunga la sfarsit. (nu se vor folosi vectori suplimentari - operatia se va realiza inplace cu un algoritm eficient - se va face o singura parcugere a vectorului). 
        /// </summary>
        static void P14()
        {
            Console.WriteLine(instructions[14]);
            var array = ReadArray();
            int left = 0;
            int right = array.Length - 1;

            while (left < right)
            {
                while (array[left] != 0)
                    left++;
                while (array[right] == 0)
                    right--;
                (array[left], array[right]) = (array[right], array[left]);
                left++;
                right--;
            }
            Console.WriteLine($"Vectorul dupa interschimbarea ceruta: {String.Join(" ", array)}");
        }

        /// <summary>
        /// Modificati un vector prin eliminarea elementelor care se repeta, fara a folosi un alt vector.  
        /// </summary>
        static void P15()
        {
            Console.WriteLine(instructions[15]);
            var list = ReadArray().ToList();

            for (int i = 0; i < list.Count - 2; i++)
                for (int j = i + 1; j < list.Count - 1; j++)
                    if (list[i] == list[j])
                        list.RemoveAt(j);

            Console.WriteLine($"Vectorul dupa stergerea dublurilor: {String.Join(" ", list)}");
        }

        /// <summary>
        /// Se da un vector de n numere naturale. Determinati cel mai mare divizor comun al elementelor vectorului. 
        /// </summary>
        static void P16()
        {
            Console.WriteLine(instructions[16]);
            var array = ReadArray();

            int cmmdc = array[0];
            for (int i = 1; i < array.Length; i++)
                cmmdc = GCD(cmmdc, array[i]);

            Console.WriteLine($"{cmmdc} este cmmdc al vectorului {String.Join(" ", array)}");
        }
        /// <summary>
        /// returns the greatest common divisor between two integers
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        private static int GCD(int a, int b)
        {
            while (b > 0)
            {
                a = b;
                b = a % b;
            }
            return a;
        }

        /// <summary>
        /// Se da un numar n in baza 10 si un numar b. 1 < b < 17. Sa se converteasca si sa se afiseze numarul n in baza b. 
        /// </summary>
        static void P17()
        {
            Console.WriteLine(instructions[17]);
            Console.Write("Dati n si b separate printr-un spatiu: ");
            var line = Console.ReadLine().Split(' ');
            int n = int.Parse(line[0]);
            int b = int.Parse(line[1]);

            if (1 < b && b < 37)
            {
                string sol = Base10ToBaseB(b, n);
                Console.WriteLine($"{n} in baza 10 este {sol} in baza {b}");
            }
            else
                Console.WriteLine($"Nu se poate converti {n} in baza {b}");
        }

        /// <summary>
        /// converts an integer from base 10 to base b and returns the result
        /// </summary>
        /// <param name="b"></param>
        /// <param name="input"></param>
        /// <returns></returns>
        private static string Base10ToBaseB(int b, int input)
        {
            char[] cifre = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' };
            string sol = "";
            Stack<char> stack = new Stack<char>();
            while (input > 0)
            {
                stack.Push(cifre[input % b]);
                input /= b;
            }
            foreach (char c in stack)
                sol += c;
            return sol;
        }

        /// <summary>
        /// Se da un polinom de grad n ai carui coeficienti sunt stocati intr-un vector. Cel mai putin semnificativ coeficient este pe pozitia zero in vector. Se cere valoarea polinomului intr-un punct x. 
        /// </summary>
        private static void P18()
        {
            Console.WriteLine(instructions[18]);
        }
        /// <summary>
        /// Se da un vector s (vectorul in care se cauta) si un vector p (vectorul care se cauta). Determinati de cate ori apare p in s. De ex. Daca s = [1,2,1,2,1,3,1,2,1] si p = [1,2,1] atunci p apare in s de 3 ori. (Problema este dificila doar daca o rezolvati cu un algoritm liniar). 
        /// </summary>
        private static void P19()
        {
            Console.WriteLine(instructions[19]);
            var s = ReadArray("s");
            var p = ReadArray("p");

            String sequence = String.Join("", s);
            String key = String.Join("", p);

            int counter = 0;
            for (int i = 0; i <= sequence.Length - key.Length; i++)
                if (key.CompareTo(sequence.Substring(i, key.Length)) == 0) // daca p se afla in s incepand de la pozitia i
                    counter++;

            Console.WriteLine($"Secventa {String.Join(" ", p)} apare de {counter} ori in vectorul {String.Join(" ", s)}");
        }
        /// <summary>
        /// Se dau doua siraguri de margele formate din margele albe si negre, notate s1, respectiv s2. Determinati numarul de suprapuneri (margea cu margea) a unui sirag peste celalalt astfel incat margelele suprapuse au aceeasi culoare. Siragurile de margele se pot roti atunci cand le suprapunem. 
        /// </summary>       
        private static void P20()
        {
            Console.WriteLine(instructions[20]);
        }
        /// <summary>
        /// Se dau doi vectori. Se cere sa se determine ordinea lor lexicografica (care ar trebui sa apara primul in dictionar). 
        /// </summary>
        private static void P21()
        {
            Console.WriteLine(instructions[21]);
            var arr1 = ReadArray("n");
            var arr2 = ReadArray("m");

            String comp1 = String.Join("", arr1);
            String comp2 = String.Join("", arr2);

            if (comp1.CompareTo(comp2) == 0)
                Console.WriteLine("Sirurile sunt egale lexicografic");
            else
                if (comp1.CompareTo(comp2) < 0)
                Console.WriteLine("Primul sir este mai mic lexicografic decat al doilea");
            else
                Console.WriteLine("Primul sir este mai mare lexicografic decat al doilea");
        }
        /// <summary>
        /// Se dau doi vectori v1 si v2. Se cere sa determine intersectia, reuniunea, si diferentele v1-v2 si v2 -v1 (implementarea operatiilor cu multimi). Elementele care se repeta vor fi scrise o singura data in rezultat. 
        /// </summary>
        private static void P22()
        {
            /*
             * mentiuni: V -> op pt reuniunea a 2 multimi, /\ -> op pt intersectia a 2 multimi 
             * M1 /\ M2 = M1 + M2 - ( (M1-M2) + (M2-M1) ) (ignorand dublurile rezultate)
             * M1 V M2 = M1 + M2 - (M1/\M2)
            */
            Console.WriteLine(instructions[22]);
            var arr1 = ReadArray("M1");
            var arr2 = ReadArray("M2");

            //M1 will be sorted and it won't admit duplicates
            SortedSet<int> M1 = new SortedSet<int>();
            foreach (var el in arr1)
                M1.Add(el);

            //M2 will be sorted and it won't admit duplicates
            SortedSet<int> M2 = new SortedSet<int>();
            foreach (var el in arr2)
                M2.Add(el);

            SortedSet<int> difM1M2 = M1minusM2(M1, M2);
            SortedSet<int> difM2M1 = M1minusM2(M2, M1);
            SortedSet<int> intersection = SetsIntersection(M1, M2);
            SortedSet<int> reunion = SetsReunion(M1, M2);

            Console.WriteLine($"M1: {String.Join(" ", M1)}");
            Console.WriteLine($"M2: {String.Join(" ", M2)}");
            Console.WriteLine($"{String.Join(" ", difM1M2)} este diferenta M1-M2");
            Console.WriteLine($"{String.Join(" ", difM2M1)} este diferenta M2-M1");
            Console.WriteLine($"{String.Join(" ", intersection)} este intersectia M1 /\\ M1");
            Console.WriteLine($"{String.Join(" ", reunion)} este reuniunea M1 V M1");
        }
        /// <summary>
        /// returns the reunion between two sets of integers as a set
        /// </summary>
        /// <param name="m1"></param>
        /// <param name="m2"></param>
        /// <returns></returns> 
        private static SortedSet<int> SetsReunion(SortedSet<int> m1, SortedSet<int> m2)
        {
            var result = new SortedSet<int>();
            foreach (var el in m1)
                result.Add(el);
            foreach (var el in m2)
                result.Add(el);
            return result;
        }
        /// <summary>
        /// returns the intersection between two sets of integers as a set
        /// </summary>
        /// <param name="m1"></param>
        /// <param name="m2"></param>
        /// <returns></returns> 
        private static SortedSet<int> SetsIntersection(SortedSet<int> m1, SortedSet<int> m2)
        {
            var result = new SortedSet<int>();
            foreach (var el in m1)
                if (m2.Contains(el))
                    result.Add(el);
            return result;
        }

        /// <summary>
        /// returns the difference between two sets of integers as a set
        /// </summary>
        /// <param name="m1"></param>
        /// <param name="m2"></param>
        /// <returns></returns> 
        private static SortedSet<int> M1minusM2(SortedSet<int> m1, SortedSet<int> m2)
        {
            SortedSet<int> sol = new SortedSet<int>();
            foreach (var el in m1)
                if (!m2.Contains(el))
                    sol.Add(el);
            return sol;
        }

        /// <summary>
        /// Aceleasi cerinte ca si la problema anterioara dar de data asta elementele din v1 respectiv v2  sunt in ordine strict crescatoare. 
        /// </summary>
        private static void P23()
        {
            Console.WriteLine(instructions[23]);
            P22();
        }
        /// <summary>
        /// Aceleasi cerinte ca si la problema anterioara dar de data asta elementele sunt stocate ca vectori cu valori binare (v[i] este 1 daca i face parte din multime si este 0 in caz contrar).
        /// </summary>
        private static void P24()
        {
            Console.WriteLine(instructions[24]);
            var arr1 = ReadArray("M1");
            var arr2 = ReadArray("M2");
            //M1 will be sorted and it won't admit duplicates
            SortedSet<int> M1 = new SortedSet<int>();
            for (int i = 0; i < arr1.Length; i++)
                if (arr1[i] != 0)
                    M1.Add(i);

            //M2 will be sorted and it won't admit duplicates
            SortedSet<int> M2 = new SortedSet<int>();
            for (int i = 0; i < arr2.Length; i++)
                if (arr2[i] != 0)
                    M2.Add(i);

            SortedSet<int> difM1M2 = M1minusM2(M1, M2);
            SortedSet<int> difM2M1 = M1minusM2(M2, M1);
            SortedSet<int> intersection = SetsIntersection(M1, M2);
            SortedSet<int> reunion = SetsReunion(M1, M2);

            Console.WriteLine($"M1: {String.Join(" ", M1)}");
            Console.WriteLine($"M2: {String.Join(" ", M2)}");
            Console.WriteLine($"{String.Join(" ", difM1M2)} este diferenta M1-M2");
            Console.WriteLine($"{String.Join(" ", difM2M1)} este diferenta M2-M1");
            Console.WriteLine($"{String.Join(" ", intersection)} este intersectia M1 /\\ M1");
            Console.WriteLine($"{String.Join(" ", reunion)} este reuniunea M1 V M1");
        }
        /// <summary>
        /// (Interclasare) Se dau doi vector sortati crescator v1 si v2. Construiti un al treilea vector ordonat crescator format din toate elementele din  v1 si v2. Sunt permise elemente duplicate. 
        /// </summary>
        private static void P25()
        {
            Console.WriteLine(instructions[25]);
            int[] arr1 = ReadArray("n");
            int[] arr2 = ReadArray("m");
            var list = new List<int>();

            Array.Sort(arr1);
            Array.Sort(arr2);

            int index1 = 0, index2 = 0;
            while (index1 < arr1.Length && index2 < arr2.Length)
            {
                if (arr1[index1] <= arr2[index2])
                    list.Add(arr1[index1++]);
                else
                    list.Add(arr2[index2++]);
            }

            while (index1 < arr1.Length)
                list.Add(arr1[index1++]);
            index1++;

            while (index2 < arr2.Length)
                list.Add(arr2[index2++]);

            Console.WriteLine($"{String.Join(" ", arr1)} + {String.Join(" ", arr2)} = {String.Join(" ", list)}");

        }
        /// <summary>
        /// Se dau doua numere naturale foarte mari (cifrele unui numar foarte mare sunt stocate intr-un vector - fiecare cifra pe cate o pozitie). Se cere sa se determine suma, diferenta si produsul a doua astfel de numere.
        /// </summary>
        private static void P26()
        {
            Console.WriteLine(instructions[26]);

            var arr1 = ReadArray("n");
            var arr2 = ReadArray("m");
            var s1 = String.Join("", arr1);
            var s2 = String.Join("", arr2);
            BigInteger nr1 = BigInteger.Parse(s1);
            BigInteger nr2 = BigInteger.Parse(s2);

            Console.WriteLine($"{nr1}+ \n{nr2} \n={nr1 + nr2}");
            Console.WriteLine();
            Console.WriteLine($"{nr1}- \n{nr2} \n={nr1 - nr2}");
            Console.WriteLine();
            Console.WriteLine($"{nr1}* \n{nr2} \n={nr1 * nr2}");
            Console.WriteLine();
        }
        /// <summary>
        ///  Se da un vector si un index in vectorul respectiv. Se cere sa se determine valoarea din vector care va fi pe pozitia index dupa ce vectorul este sortat. 
        /// </summary>
        private static void P27()
        {
            Console.WriteLine(instructions[27]);
            var array = ReadArray();
            Console.Write($"Dati k (o pozitie din vector, 0<=k<={array.Length - 1})");
            int k = int.Parse(Console.ReadLine());

            Array.Sort(array);
            Console.WriteLine($"v[{k}] in urma sortarii este {array[k]}: {String.Join(" ", array)}");
        }
        /// <summary>
        /// Quicksort. Sortati un vector folosind metoda QuickSort. 
        /// </summary>
        private static void P28()
        {
            Console.WriteLine(instructions[28]);
            var array = ReadArray();
            QuickSort(array, 0, array.Length - 1);
            Console.WriteLine($"Vectorul dupa sortare: {String.Join(" ", array)}");
        }

        private static void QuickSort(int[] array, int left, int right)
        {
            if (left < right)
            {
                int p = partition(array, left, right);
                QuickSort(array, left, p-1);
                QuickSort(array, p+1, right);
            }
        }

        private static int partition(int[] array, int left, int right)
        {
            int pivot = array[right];
            int i = left - 1;
            for (int j = left; j < right; j++)
            {
                if (array[j] <= pivot)
                {
                    i++;
                    (array[i], array[j]) = (array[j], array[i]);
                }
            }
            i++;
            (array[i], array[right]) = (array[right], array[i]);
            return i;
        }

        /// <summary>
        /// MergeSort. Sortati un vector folosind metoda MergeSort.
        /// </summary>
        private static void P29()
        {
            Console.WriteLine(instructions[29]);
            var array = ReadArray();
            int[] aux = new int[array.Length];
            MergeSort(array,aux,0,array.Length-1);
            Console.WriteLine($"Vectorul dupa sortare: {String.Join(" ", array)}");
        }

        private static void MergeSort(int[] array, int[] aux, int left, int right)
        {
            if (left < right)
            {
                int mid = left + (right - left) / 2;
                MergeSort(array, aux, left, mid);
                MergeSort(array, aux, mid + 1, right);

                int i = left, j = mid + 1, k = 0;
                while (i <= mid && j <= right)
                    if (array[i] <= array[j])
                        aux[k++] = array[i++];
                    else
                        aux[k++] = array[j++];

                while (i <= mid)
                    aux[k++] = array[i++];

                while (j <= right)
                    aux[k++] = array[j++];

                for (i = left; i <= right; i++)
                    array[i] = aux[i - left];
            }
            else
                return;
        }

        /// <summary>
        /// Sortare bicriteriala. Se dau doi vectori de numere intregi E si W, unde E[i] este un numar iar W[i] este un numar care reprezinta ponderea lui E[i]. Sortati vectorii astfel incat elementele lui E sa fie in in ordine crescatoare iar pentru doua valori egale din E, cea cu pondere mai mare va fi prima. 
        /// </summary>
        private static void P30()
        {
            Console.WriteLine(instructions[30]);
            var E = ReadArray();
            var W = ReadArray();
            if (E.Length == W.Length)
            {
                int[] aux1 = new int[E.Length];
                int[] aux2 = new int[E.Length];
                //merge sort is not the best option here due to it's bad space complexity
                //but I choosed it for it's time complexity O(nlogn) and because I understand how it works
                MergeSort(E,W, aux1,aux2, 0, E.Length - 1);
                Console.WriteLine($"Vectorii dupa sortare: \n{String.Join(" ", E)}\n{String.Join(" ", W)}");
            }
            else
                Console.WriteLine("Vectorii trebuie sa aiba aceeasi lungime!");
        }

        private static void MergeSort(int[] crt1, int[] crt2, int[] aux1, int[] aux2, int left, int right)
        {
            if (left < right)
            {
                int mid = left + (right - left) / 2;
                MergeSort(crt1, crt2, aux1,aux2, left, mid);
                MergeSort(crt1, crt2, aux1,aux2, mid + 1, right);

                int i = left, j = mid + 1, k = 0;
                while (i <= mid && j <= right)
                    if (crt1[i] < crt1[j])
                    {
                        aux1[k] = crt1[i];
                        aux2[k++] = crt2[i++];
                    }
                    else
                        if(crt1[i] > crt1[j])
                        {
                            aux1[k] = crt1[j];
                            aux2[k++] = crt2[j++];
                        }
                        else
                        {
                            if (crt2[i]<= crt2[j])
                            {
                                aux1[k] = crt1[i];
                                aux2[k++] = crt2[i++];
                            }
                            else
                            {
                                aux1[k] = crt1[j];
                                aux2[k++] = crt2[j++];
                            }
                        }

                while (i <= mid)
                {
                    aux1[k] = crt1[i];
                    aux2[k++] = crt2[i++];
                }

                while (j <= right)
                {
                    aux1[k] = crt1[j];
                    aux2[k++] = crt2[j++];
                }

                for (i = left; i <= right; i++)
                {
                    crt1[i] = aux1[i - left];
                    crt2[i] = aux2[i - left];
                }
            }
            else
                return;
        }

        /// <summary>
        /// (Element majoritate). Intr-un vector cu n elemente, un element m este element majoritate daca mai mult de n/2 din valorile vectorului sunt egale cu m (prin urmare, daca un vector are element majoritate acesta este unui singur).  Sa se determine elementul majoritate al unui vector (daca nu exista atunci se va afisa <nu exista>). (incercati sa gasiti o solutie liniara). 
        /// </summary>
        private static void P31()
        {
            Console.WriteLine(instructions[31]);
            var array = ReadArray();

            Dictionary<int,int> map = new Dictionary<int,int>();
            foreach (var el in array)
            {
                if(!map.ContainsKey(el))
                    map.Add(el, 1);
                else
                    map[el]++;//frecventa elementelor creste
            }

            int searchedValue = 0 ;
            bool ok = false;
            foreach(var pair in map)
            {
                if (pair.Value > array.Length / 2)
                {
                    ok = true;
                    searchedValue = pair.Key;
                    break;
                }
            }

            if (ok)
                Console.WriteLine($"{searchedValue} este element majoritar");
            else
                Console.WriteLine($"Vectorul {String.Join(" ",array)} nu are element majoritar");
        }
    }  
}
