import math

n = int(input())
noList = list(map(int, input().split()))

result = math.gcd(noList[0],noList[1])
for i in range(2, n):
	result = math.gcd(result, noList[i])

print(result*n)