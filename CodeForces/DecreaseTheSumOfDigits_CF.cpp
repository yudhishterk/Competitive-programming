#include<bits/stdc++.h>

using namespace std;

int GetSum(long long n){
	int sum = 0;
	while(n>0){
		sum+=n%10;
		n = n/10;
	}
	return sum;
}

long long CalcMoves(string n, int s){
	int sum = 0;
	int i=0;
	while(i<n.size()){
		int digit = n[i]-'0';
		if(sum+digit>=s) break;
		
		sum += digit;
		i++;
	}
	long long a = stoll(n.substr(i));
	long long b = stoll("1" + string(n.size()-i, '0'));
	
	return b-a;
}

int main(){
	int t;
	cin >> t;
	
	for(int i=0; i<t; i++){
		
		long long n;
		int s;
		cin >> n >> s;
		
		if(GetSum(n)<=s){
			cout << 0 << "\n";
			continue;
		}
		
		string no = to_string(n);
		
		cout << CalcMoves(no, s) << "\n";		
		}
	
	return 0;
}