for _ in range(int(input())):
	n = int(input())
	a = list(map(int,input().split()))
	b = list(map(int,input().split()))
	
	min_a = min(a)
	min_b = min(b)
	
	result = 0
	
	for i in range(n):
		rem_a = a[i]-min_a
		rem_b = b[i]-min_b
		result += max(rem_a, rem_b)
		
	print(result)