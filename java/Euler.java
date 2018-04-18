

public class Euler {

    int get_int_cli(){
        String input = System.console().readLine();
        int N = -1;
        try {
            N = Integer.parseInt(input);

            System.out.format("input value %i", N);
        }
        catch (Exception e){
            System.out.format("Exception %s", e);
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
        System.out.format("result : %i \n", sum);

        return 0;
    }

    int problem_two(int MAX_LENGTH){
        int N;
        int[] fibo;
        int i, j;
        int sum;
        N = get_int_cli();
        System.out.format("%i \n", N);
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
        System.out.format("result : %i \n", sum);

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

        System.out.format("Fulfilled eratosthenes crible \n");

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

        System.out.format("Largest prime factor : %i \n", primes[largest_rank]);

        return primes[largest_rank];
    }

    public static void main(String []args){
        Euler euler = new Euler();

        String[] descr =
        {
            "Find the sum of all the multiples of 3 or 5 below N \n",
            "Sum of even-valued Fibonacci numbers below ... \n",
            "Largest prime factor"
        };
        int MAX_LENGTH = 10000000;

        System.out.format("Euler Project");

        // choose your problem
        String input = System.console().readLine();
        int pb_num = -1;
        try {
            pb_num = Integer.parseInt(input);

            System.out.format("input value %i", pb_num);
        }
        catch (Exception e){
            System.out.format("Exception %s", e);
        }

        switch (pb_num){
            case 1 :
            System.out.format(descr[pb_num - 1]);
            euler.problem_one(MAX_LENGTH);

            break;

            case 2 :
            System.out.format(descr[pb_num - 1]);
            euler.problem_two(MAX_LENGTH);

            break;

            case 3 :
            System.out.format(descr[pb_num - 1]);
            euler.problem_three(MAX_LENGTH);

            break;

            default :
            System.out.format("problem not implemented yet");
            return ;
        }
    }
}