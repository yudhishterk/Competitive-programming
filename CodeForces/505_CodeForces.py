def checkNeighbours(mat, i, j, n, m):
    if(mat[i][j]):
        return 0
    
    mat[i][j]=True
    
    if(i+1>=n and j+1>=m):
        return 1
    if(i+1>=n):
        mat[i][j+1]=True
        return 1    
    if(j+1>=m):
        mat[i+1][j]=True
        return 1
    #print("i",i,"j",j,"r",mat[i][j+1],"d",mat[i+1][j],"diag",mat[i+1][j+1])
    if(mat[i+1][j]==False and mat[i][j+1]==False and mat[i+1][j+1]==False):
        mat[i+1][j]=True
        mat[i][j+1]=True
        mat[i+1][j+1]=True
        return 1
        
    result = 0
    if(mat[i+1][j]==False):
        mat[i+1][j] = True
        result+=1
    if(mat[i][j+1]==False):
        mat[i][j+1] = True
        result+=1
    
    return max(result,1)
    
def CountMinFalseValues(mat,n,m):
    count = 0
    for i in range(n):
        for j in range(m):
            count+=checkNeighbours(mat, i, j, n, m)
            #print("count",count,"mat", mat)
    return count

def OddMatToBoolArray(mat, n, m):
    result = []
    for i in range(n-1):
        innerArr = []
        for j in range(m-1):
            if((mat[i][j]+mat[i+1][j]+mat[i][j+1]+mat[i+1][j+1])%2==0):
                innerArr.append(False)
            else:
                innerArr.append(True)
        result.append(innerArr)
    return result

n,m = map(int, input().split())
mat = []
for _ in range(n):
    mat.append(list(map(int,list(input()))))
 
if(n>=4 and m>=4):
    print(-1)
else:
    if(n==1 or m==1):
        if(sum(map(sum, mat))%2==0):
            print(1)
        else:
            print(0)
    else:
        mappedMat = OddMatToBoolArray(mat, n, m)
        #print(mappedMat)
        count = CountMinFalseValues(mappedMat, n-1, m-1)
        print(count)