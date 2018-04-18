import sys

descr = [
    "Find the sum of all the multiples of 3 or 5 below N \n",
    "Sum of even-valued Fibonacci numbers below ... \n",
    "Largest prime factor" 
]

def get_int_cli() :

    n = input()
    try :
        return int(n)
    except ValueError :
        print("Not an integer") 
    


def problem_one(MAX_LENGTH) :
    
    sum = 0
    for i in range(MAX_LENGTH) :
        if (i%5 == 0) | (i%3 == 0) :
            sum += i
        
    print("result %s" % sum)

def problem_two(MAX_LENGTH) :

    fibo = [0] * MAX_LENGTH
    fibo[0] = 1
    fibo[1] = 2
    i = 2
    N = get_int_cli()
    while (i < MAX_LENGTH) & fibo[i-1] < N :
        fibo[i] = fibo[i-1] + fibo[i-2]
        i+=1

    sum = 0
    for i in range(i) :
        if fibo[j] % 2 == 0 :
            sum += fibo[j]

    print("result %s" % sum)

    

def main() :

    """ Euler project """
    MAX_LENGTH = 10000000
    print("Select number of problem")
    pb_num = input()
    try :
        pb_num = int(pb_num)
    except ValueError :
        print("Not an integer")
        return

    if pb_num == 1 :
        print(descr[pb_num - 1])
        problem_one(MAX_LENGTH)
        return
    if pb_num == 2 :
        print(descr[pb_num - 1])
        problem_two(MAX_LENGTH)
        return

if __name__ == "__main__" :
    main()