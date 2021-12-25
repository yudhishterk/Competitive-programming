/*
https://www.hackerrank.com/challenges/jack-goes-to-rapture/problem
*/

#include <bits/stdc++.h>

using namespace std;

string ltrim(const string &);
string rtrim(const string &);
vector<string> split(const string &);

void getCost(int n, int e, vector<int> from, vector<int> to, vector<int> weight) {
    //Using Dijkstra's algorithm
  
    priority_queue<pair<int, int>> q;
    
    //Distance of each node from node 0
    int distance[n];
    //Stores the processed nodes
    bool processed[n];
    
    for(int i=0; i<n; i++){
        distance[i] = INT_MAX;
        processed[i] = false;
    }
    
    //Create adjacency list
    vector<vector<pair<int,int>>> adj;
    
    for(int i=0 ; i<n; i++){
        adj.push_back({});
    }
    
    for(int i=0 ; i<e; i++){
        adj[from[i]-1].push_back({to[i]-1, weight[i]});
        adj[to[i]-1].push_back({from[i]-1, weight[i]});
    }
    
    distance[0] = 0;
    q.push({0,0});
    
    while(!q.empty()){
        int a = q.top().second; q.pop();
        if(processed[a]) continue;
        processed[a] = true;
        
        for(auto u: adj[a]) {
            int b = u.first, w = u.second;
            if(max(distance[a], w) < distance[b]){
                distance[b] = max(distance[a], w);
                q.push({-distance[b], b});
            }
        }
    }
    
    if(distance[n-1] < INT_MAX)
        cout << distance[n-1];
    else
        cout << "NO PATH EXISTS";
}

int main()
{
    string g_nodes_edges_temp;
    getline(cin, g_nodes_edges_temp);

    vector<string> g_nodes_edges = split(rtrim(g_nodes_edges_temp));

    int g_nodes = stoi(g_nodes_edges[0]);
    int g_edges = stoi(g_nodes_edges[1]);

    vector<int> g_from(g_edges);
    vector<int> g_to(g_edges);
    vector<int> g_weight(g_edges);

    for (int i = 0; i < g_edges; i++) {
        string g_from_to_weight_temp;
        getline(cin, g_from_to_weight_temp);

        vector<string> g_from_to_weight = split(rtrim(g_from_to_weight_temp));

        int g_from_temp = stoi(g_from_to_weight[0]);
        int g_to_temp = stoi(g_from_to_weight[1]);
        int g_weight_temp = stoi(g_from_to_weight[2]);

        g_from[i] = g_from_temp;
        g_to[i] = g_to_temp;
        g_weight[i] = g_weight_temp;
    }

    getCost(g_nodes, g_edges, g_from, g_to, g_weight);

    return 0;
}

string ltrim(const string &str) {
    string s(str);

    s.erase(
        s.begin(),
        find_if(s.begin(), s.end(), not1(ptr_fun<int, int>(isspace)))
    );

    return s;
}

string rtrim(const string &str) {
    string s(str);

    s.erase(
        find_if(s.rbegin(), s.rend(), not1(ptr_fun<int, int>(isspace))).base(),
        s.end()
    );

    return s;
}

vector<string> split(const string &str) {
    vector<string> tokens;

    string::size_type start = 0;
    string::size_type end = 0;

    while ((end = str.find(" ", start)) != string::npos) {
        tokens.push_back(str.substr(start, end - start));

        start = end + 1;
    }

    tokens.push_back(str.substr(start));

    return tokens;
}
