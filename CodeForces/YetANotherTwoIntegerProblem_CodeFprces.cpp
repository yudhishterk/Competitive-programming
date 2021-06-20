#include<bits/stdc++.h>

using namespace std;

int trans(int k){
    int count = 0;
    count+=k/10;
    if(k%10!=0) count++;
    return count;
}

int main(){
    int n,a,b;
    cin>>n;
    while(n>0){
        cin>>a>>b;
        int diff = abs(a-b);
        cout << trans(diff) << "\n";
        n--;
    }
    
    return 0;
}