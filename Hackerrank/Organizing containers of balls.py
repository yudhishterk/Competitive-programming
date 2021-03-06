Problem: https://www.hackerrank.com/challenges/organizing-containers-of-balls/problem

Solution: Sum of columns should match with sum of rows in any order to make the swaps possible.

for _ in range(int(input())):
    n = int(input())
    containers = []
    
    for i in range(n):
        con = list(map(int, input().split()))
        containers.append(con)
        
    columns = [0]*n
    rows = []
    
    for i in range(n):
        rows.append(sum(containers[i]))
        
    for i in range(n):
        for j in range(n):
            columns[j] += containers[i][j]
            
    rows.sort()
    columns.sort()
    
    result = True
    
    for i in range(n):
        if(rows[i] != columns[i]):
            result = False
            
    print("Possible" if result else "Impossible")
