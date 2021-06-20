#include<bits/stdc++.h>

using namespace std;

int main(){
	int t, n;
	string line;
	
	cin >>t;
	for(int _=0; _<t; _++){
	    
	    unordered_map<char,int> m;
		cin>>n;
		for(int i=0; i<n;i++){
			cin>>line;
			for(auto c:line) m[c]++;
		}
		
		bool result = true;
    	for(auto i:m) if(i.second%n!=0) result = false;
    	
    	string ans = result?"YES":"NO";
    	cout << ans << "\n";
	}
	return 0;
}