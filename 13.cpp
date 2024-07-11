#include<bits/stdc++.h>
using namespace std;

int main(){
	string s;
	cin >> s;
	int x, y;
	cin >> x >> y;
	
	int cnt1 = 0, cnt2 = 0;
	int left = 0; 
	int result = 0;
	for (int right = 0; right < s.size(); right++){
		if (s[right] == '2'){
			cnt1++;
		}
		if (s[right] == '8'){
			cnt2++;
		}
		
		while (cnt1 > x || cnt2 > y){
			if (s[left] == '2'){
				cnt1--;
			}
			if (s[left] == '8'){
				cnt2--;
			}
			left++;
		}
		result = max(result, right - left + 1);
	}
	
	cout << result;
}