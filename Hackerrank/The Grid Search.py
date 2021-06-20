R = 0
C = 0
r = 0
c = 0
grid = []
pattern = []

def LookupPattern(i,j):
    global R,C,r,c,grid,pattern
    
    if(i+r > R or j+c > C):
        return False
    
    for a in range(r):
        if(grid[i+a][j:j+c] != pattern[a]):
            return False
        
    return True

def Search():
    global R,C,r,c,grid,pattern
    
    for i in range(R):
        for j in range(C):
            if(LookupPattern(i,j)):
                return "YES"
            
    return "NO"

for _ in range(int(input())):
    R,C = map(int, input().split())
    grid = []
    
    for i in range(R):
        grid.append(input())
        
    r,c = map(int, input().split())
    pattern = []
    
    for i in range(r):
        pattern.append(input())
        
    print(Search())