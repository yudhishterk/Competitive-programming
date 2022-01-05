'''
https://www.hackerrank.com/challenges/sherlock-and-anagrams/problem
'''

#!/bin/python3

import math
import os
import random
import re
import sys

#
# Complete the 'sherlockAndAnagrams' function below.
#
# The function is expected to return an INTEGER.
# The function accepts STRING s as parameter.
#

def Ana(s1, s2):
    n = len(s1)
    m = len(s2)
    if(n > m):
        return 0
    
    ascii_a = ord('a')
    n_l = [0]*26
    for c in s1:
        n_l[ord(c)-ascii_a] += 1
    
    count = 0
    for i in range(m-n+1):
        m_l = [0]*26
        for c in s2[i:i+n]:
            m_l[ord(c)-ascii_a] += 1
        
        j = 0
        while(j < 26 and n_l[j]==m_l[j]):
            j+=1
        count += 1 if j==26 else 0
    return count

def sherlockAndAnagrams(s):
    count = 0
    n = len(s)
    for i in range(n-1):
        for j in range(i+1, n):
            count += Ana(s[i:j][::-1], s[i+1:])
                
    return count
        

if __name__ == '__main__':
    fptr = open(os.environ['OUTPUT_PATH'], 'w')

    q = int(input().strip())

    for q_itr in range(q):
        s = input()

        result = sherlockAndAnagrams(s)

        fptr.write(str(result) + '\n')

    fptr.close()
