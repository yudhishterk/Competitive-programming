for _ in range(int(input())):
	n, m = map(int, input().split())
	lastCol = ""
	lastRow = ""
	for i in range(n):
		if(i==n-1):
			lastRow = input()
			continue
		row = input()
		lastCol+=row[m-1]
		
	print(lastCol.count('R')+lastRow.count('D'))