#include <iostream>
using namespace std;

 int a,b,n=10;
 int o;

int main()
{
   cin >> a;
   cin >> b;
   for(int i=0;i=n;i++)
   {
       o += 1;

       for(int j=0;j=n-1;j++)
       {
           o+=1;
           if(a>b)a = a-b;
           else a=b-a;
       }
   }
    cout << a << endl;
    return 0;

    
}