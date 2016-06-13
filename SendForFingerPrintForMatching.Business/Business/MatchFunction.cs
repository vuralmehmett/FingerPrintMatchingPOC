using SampleFingerPrintRecognation.Business.FingerPrintMatch;

namespace SendForFingerPrintForMatching.Business.Business
{
    public class MatchFunction
    {
        public double Matching(string imagePath)
        {
            FingerPrintMatching fingerPrintMatching = new FingerPrintMatching();
            return fingerPrintMatching.Matching(imagePath);
        }
    }
}
