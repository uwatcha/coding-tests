#include <bits/stdc++.h>
#include <vector>
#include <climits>
#include <cstdlib>
using namespace std;

int main()
{
    #ifdef DEBUG
    freopen("input_3.txt", "r", stdin);
    #endif
    ios::sync_with_stdio(false);
    cin.tie(nullptr);

    int N;
    cin >> N;

    vector<int> heights(N);
    vector<int> dp(N);
    for (int i=0; i<N; i++)
    {
        int h;
        cin >> h;
        heights[i] = h;

        dp[i] = INT_MAX;
    }

    for (int i=0; i<N; i++)
    {
        if (i==0)
        {
            dp[i] = 0;
        }
        else if (i==1)
        {
            dp[i] = abs(heights[i]-heights[i-1]);
        }
        else
        {
            int oneJumpCostSum = dp[i-1] + abs(heights[i]-heights[i-1]);
            int twoJumpCostSum = dp[i-2] + abs(heights[i]-heights[i-2]);
            int lowerCostSum = oneJumpCostSum < twoJumpCostSum ? oneJumpCostSum : twoJumpCostSum;
            dp[i] = lowerCostSum;
        }
    }
    cout << dp[N-1] << '\n';
    return 0;
}

bool chmin(int &a, int b)
{
    if (a < b)
    {
        a = b;
        return true;
    }
    return false;
}
