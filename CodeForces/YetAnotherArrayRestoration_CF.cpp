#include<bits/stdc++.h>

using namespace std;

int GetInterval(int n, int x, int y){	
	for(int i = n-1; i>0; i--){
		if((y-x)%i==0) return (y-x)/i;
	}
	return y-x;
}

int GetStart(int interval ,int x, int y, int n){
    int k = (y-x)/interval+1;
    if(k==n) return x;
    
    int backSteps = min(x/interval, n-k);
    int val = x-(interval*backSteps);
    if(val==0) val+=interval;
    
    return val;
}

int main(){
	int t;
	cin >> t;
	
	while(t>0){
		int n, x ,y;
		cin >> n >> x >> y;
		
		int interval = GetInterval(n, x, y);
		int start = GetStart(interval, x, y, n);
		
		while(n>0){
			if(n==1) cout << start << "\n";
			else cout << start << " ";
			start+=interval;			
			n--;
		}
		
		t--;
		}
	
	return 0;
}