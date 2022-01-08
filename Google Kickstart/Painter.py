'''
https://codingcompetitions.withgoogle.com/kickstart/round/0000000000435914/00000000008d9a88#problem
'''
for t in range(int(input())):
    n = int(input())
    s = input()
    
    r = [False]*n
    y = [False]*n
    b = [False]*n
    
    for i in range(n):
        if(s[i] in ('R', 'O', 'P', 'A')):
            r[i] = True
        if(s[i] in ('Y', 'O', 'G', 'A')):
            y[i] = True
        if(s[i] in ('B', 'P', 'G', 'A')):
            b[i] = True
            
    count = 0
    for i in range(n):
        if(r[i] and (i == 0 or r[i-1] == False)):
            count += 1
        if(y[i] and (i == 0 or y[i-1] == False)):
            count += 1
        if(b[i] and (i == 0 or b[i-1] == False)):
            count += 1
    
    print('Case #%d: %d'%(t+1, count))
