// 1. Чи правильно в данному прикладі проходить обробка помилок.
// 2. Що таке стек трейс 
// 3. Що таке блок finaly та коли він вкористовуєтся
// 4. Чи можна до одного блоку try, додати декылька блоків catch

int x = 10;
//int indexer = 1;
int indexer = 3;
int[] array = new int[3] { 1, 0, 3 };

try
{
    int res = x / array[indexer];
}
catch (Exception exp)
{
    Console.WriteLine(exp.Message);
}
