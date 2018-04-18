#include <stdio.h>
#include <stdlib.h>

#define MIN(a,b) (((a)<(b))?(a):(b))
#define MAX(a,b) (((a)>(b))?(a):(b))

char descr[3][1024] = 
{
    "Find the sum of all the multiples of 3 or 5 below N \n",
    "Sum of even-valued Fibonacci numbers below ... \n",
    "Largest prime factor"
};

int get_int_cli(int *N){
    int res;
    res = scanf("%i", N);
    if (res != 1){
        printf("badly formatted N value \n");
        exit(-1);
    }
    else{
        return 0;
    }
}

int problem_one(int MAX_LENGTH) {
    int N;
    int res2;
    int sum;
    int i;

    get_int_cli(&N);

    sum = 0;
    for (i=0;i<N;i++){
        if (i % 5 == 0 || i % 3 == 0){
            sum += i;
        }
    }
    printf("result : %i \n", sum);

    return 0;
}

int problem_two(int MAX_LENGTH){
    int N;
    int *fibo;
    int i, j;
    int sum;
    get_int_cli(&N);
    printf("%i \n", N);
    fibo = malloc(MAX_LENGTH*sizeof(int));
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
    free(fibo);
    printf("result : %i \n", sum);

    return 0;
}

int create_eratos(int MAX_LENGTH, int MAX_PRIME, int* eratos, int* primes){
    int N;
    int i,j,k;
    
    eratos = calloc(MAX_LENGTH, sizeof(int));
    primes = malloc(MAX_PRIME * sizeof(int));

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

    printf("Fulfilled eratosthenes crible \n");

    return eratos, primes, k;
}

int problem_three(int MAX_LENGTH){
    int N;
    int largest_rank = 1;
    int M;
    int *eratos;
    int *primes;
    int k;

    get_int_cli(&N);
    k = create_eratos(MAX_LENGTH, 1000, eratos, primes);

    M = N;
    while(M>1){
        while (M % primes[largest_rank] == 0){
            M = M / primes[largest_rank];
        }
        largest_rank++;
    }
    free(eratos);
    free(primes);

    printf("Largest prime factor : %i \n", primes[largest_rank]);
}

int main(int argc, char *argv[]){

    int pb_num = 0;
    int res = 0;

    int MAX_LENGTH = 10000000;

    // choose your problem
    printf("Select number of problem \n");

    res = scanf("%i", &pb_num);
    printf("input value %i \n", pb_num);
    if (res != 1){
        printf("badly formatted input");
        return -1;
    }
    else {
         switch (pb_num){
            case 1 :
            printf(descr[pb_num - 1]);
            problem_one(MAX_LENGTH) ;

            break;

            case 2 :
            printf(descr[pb_num - 1]);
            problem_two(MAX_LENGTH);

            break;

            case 3 :
            printf(descr[pb_num - 1]);
            problem_three(MAX_LENGTH);

            break;

            default :
            printf("problem not implemented yet");
            return 0;
         }
    }
} 