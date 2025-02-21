var arr = new int[] { 5, 6, 9, 1, 2, 3, 4 };

for (int i = 0; i < arr.Length; i++)
{
    for (int j = 0; j < arr.Length; j++){ 
        var res = 0;
        if (arr[i] < arr[j]) {
        res = arr[i];
        arr[i] = arr[j];
        arr[j] = res;
        }
    }
}
foreach (int i in arr)
    Console.WriteLine(i);