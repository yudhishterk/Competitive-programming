#include<bits/stdc++.h>

using namespace std;

double RootValue(long long val, long long base){
	double d = exp(log(val)/(double)base);
	return d;
}

int main(){
	vector<long long> v;
	long long n;
	long long input;
	
	cin>>n;
	
	for(long long i=0; i<n; i++){
		cin>> input;
		v.push_back(input);		
	}
	
	sort(v.begin(), v.end());
	long long last = v.back();
	double x = RootValue(last, n-1);
	long long y = abs(pow(floor(x), n-1)-last)<abs(pow(ceil(x), n-1)-last)?floor(x):ceil(x);
	long long result = 0;
	
	for(long long i=0; i<n; i++){
		result+=abs(v[i]-pow(y, i));
	}
	
	cout << result;
	
	return 0;
}
