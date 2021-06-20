for _ in range(int(input())):
	n = int(input())
	if(n==1):
		input()
		print("Yes")
		continue
	a = list(map(int, input().split()))
	a.sort()
	flag = True
	for i in range(n-1):
		if(a[i+1]-a[i]>1):
			flag = False
	if(flag):
		print("Yes")
	else:
		print("No")