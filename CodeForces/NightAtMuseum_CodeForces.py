def NightAtMuseum(word):
	curChr = ord('a')
	totalMoves = 0
	
	for ch in word:
	    chV = ord(ch)
	    diff = abs(curChr-chV)
	    totalMoves+= diff if diff<13 else 13-(diff%13)
	    curChr = chV
	    
	return totalMoves
	
inputStr = input()
print(NightAtMuseum(inputStr))