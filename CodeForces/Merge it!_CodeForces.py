for _ in range(int(input())):
	n = int(input())
	noList = list(map(int,input().split()))
	
	reducedList = list(map(lambda x: x%3 ,noList))
	
	result = reducedList.count(0)
	ones = reducedList.count(1)
	twos = reducedList.count(2)
	
	if(ones>twos):
		result += twos
		ones -= twos
		result += ones//3
	else:
		result+=ones
		twos -= ones
		result += twos//3
	print(result)