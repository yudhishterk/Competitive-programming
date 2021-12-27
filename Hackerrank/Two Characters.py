'''
https://www.hackerrank.com/challenges/two-characters/problem
'''

#!/bin/python3

import math
import os
import random
import re
import sys

def alternate(s):
    n = len(s)
    
    if(n <= 1):
        return 0
    
    result = 0
    ascii_a = ord('a')
    for i in range(26):
        a = chr(i + ascii_a)
        if a not in s:
            continue
        for j in range(i+1, 26):
            b = chr(j + ascii_a)
            if b not in s:
                continue
            prev = '#'
            count = 0
            valid = True
            for c in s:
                if c not in a+b:
                    continue
                if(c == prev):
                    valid = False
                    break
                prev = c
                count += 1
            if(valid):
                result = max(result, count)
    
    return result

if __name__ == '__main__':
    fptr = open(os.environ['OUTPUT_PATH'], 'w')

    l = int(input().strip())

    s = input()

    result = alternate(s)

    fptr.write(str(result) + '\n')

    fptr.close()
