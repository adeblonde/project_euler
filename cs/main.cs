using System;



namespace EulerProject {
    class Euler {

        int get_int_cli(){
            string input = Console.ReadLine();
            string[] inputs = input.Split(' ');
            int N = -1;
            try {
                N = int.Parse(inputs[0]);

                Console.WriteLine("input value {0}", N);
            }
            catch (Exception e){
                if (e.Source != null){
                    Console.WriteLine("Exception {0} with source {1} occured", e, e.Source);
                }
            }

            return N;
        }

        int problem_one(int MAX_LENGTH) {
            int N;
            int sum;
            int i;

            N = get_int_cli();

            sum = 0;
            for (i=0;i<N;i++){
                if (i % 5 == 0 || i % 3 == 0){
                    sum += i;
                }
            }
            Console.WriteLine("result : {0} \n", sum);

            return 0;
        }

        int problem_two(int MAX_LENGTH){
            int N;
            int[] fibo;
            int i, j;
            int sum;
            N = get_int_cli();
            Console.WriteLine("{0} \n", N);
            fibo = new int[MAX_LENGTH];
            fibo[0] = 1;
            fibo[1] = 2;
            i = 2;
            while(i < MAX_LENGTH && fibo[i-1] < N){
                fibo[i] = fibo[i-1] + fibo[i-2];
                i++;
            }
            sum = 0;
            for (j=0; j<i; j++){
                if (fibo[j] % 2 == 0){
                    sum += fibo[j];
                }
            }
            Console.WriteLine("result : {0} \n", sum);

            return 0;
        }

        int create_eratos(int MAX_LENGTH, int MAX_PRIME, int[] eratos, int[] primes){
            int i,j,k;
            
            // create eratosthenes crible
            k = 1;
            primes[0] = 1;
            for (i = 2; i<MAX_PRIME;i++){
                if (eratos[i] == 0){
                    for (j=i*2;j<MAX_LENGTH;j+=i){
                        eratos[j] = 1;
                    }
                    primes[k] = i;
                    k++;
                }
            }

            Console.WriteLine("Fulfilled eratosthenes crible \n");

            return k;
        }

        int problem_three(int MAX_LENGTH){
            int N;
            int largest_rank = 1;
            int M;
            int MAX_PRIME = 1000;
            int[] eratos = new int[MAX_LENGTH];
            int[] primes = new int[MAX_PRIME];
            int k;

            N = get_int_cli();
            k = create_eratos(MAX_LENGTH, MAX_PRIME, eratos, primes);

            M = N;
            while(M>1){
                while (M % primes[largest_rank] == 0){
                    M = M / primes[largest_rank];
                }
                largest_rank++;
            }

            Console.WriteLine("Largest prime factor : {0} \n", primes[largest_rank]);

            return primes[largest_rank];
        }


        static void Main(string[] args){

            Euler euler = new Euler();

            string[] descr =
            {
                "Find the sum of all the multiples of 3 or 5 below N \n",
                "Sum of even-valued Fibonacci numbers below ... \n",
                "Largest prime factor"
            };
            const int MAX_LENGTH = 10000000;

            Console.WriteLine("Euler Project");

            // choose your problem
            string input = Console.ReadLine();
            string[] inputs = input.Split(' ');
            int pb_num = -1;
            try {
                pb_num = int.Parse(inputs[0]);

                Console.WriteLine("input value {0}", pb_num);
            }
            catch (Exception e){
                if (e.Source != null){
                    Console.WriteLine("Exception {0} with source {1} occured", e, e.Source);
                }
            }

            switch (pb_num){
                case 1 :
                Console.WriteLine(descr[pb_num - 1]);
                euler.problem_one(MAX_LENGTH);

                break;

                case 2 :
                Console.WriteLine(descr[pb_num - 1]);
                euler.problem_two(MAX_LENGTH);

                break;

                case 3 :
                Console.WriteLine(descr[pb_num - 1]);
                euler.problem_three(MAX_LENGTH);

                break;

                default :
                Console.WriteLine("problem not implemented yet");
                return ;
            }
            
        }
    }
}