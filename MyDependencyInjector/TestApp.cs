namespace MyDependencyInjector;

public class TestApp{
    private int counter;
    private static List<long> _knownPrimeNumbers = new(){ 2, 3 };
    private static long _maxChecked = 3;

    public TestApp()
    {
        this.counter = 0;
    }

    public void Run(){

    }

    public bool IsPrime(long n){
        if (n <= 1)
            return false;
        if(n <= 3)
            return true;
        if(_knownPrimeNumbers.Contains(n))
            return true;
        
        if(n < _knownPrimeNumbers.Max())
            return false;

        if(n <= _maxChecked)
            return false;

        return CheckUnknownForPrimality(n);
    }

    private bool CheckUnknownForPrimality(long n)
    {
        List<long> checkList = _knownPrimeNumbers.Where(_ => _ < n/2).ToList();

        long maxKnown = _knownPrimeNumbers.Max();

        while(maxKnown <= n){
            _maxChecked = maxKnown;
            //not prime
            if(checkList.Any(x => (maxKnown % x) == 0)){
                continue;
            }

            _knownPrimeNumbers.Add(maxKnown);

            if(maxKnown < n/2){
                checkList.Add(maxKnown);
            }
        }  

        return _knownPrimeNumbers.Contains(n);
    }
}