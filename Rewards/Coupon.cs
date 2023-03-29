namespace LittleWebApplication.Rewards
{
    public class Coupon
    {
        int couponNumber;
        string couponCompany;
        string couponCategory;
        string couponBenefit;
        string couponDescription;
        int couponMaxStock;
        //int couponValidityPeriod;
        //double couponWinningChance;
        //int couponStocklevel;
        //Eunums couponStatus;
        //bool specialCoupon;
        //int specialCouponCompleteSeries;
        //int specialCouponSeriesNumber;
        //doc couponBarCode;

        public static Coupon CreateCoupon()
        {
            Coupon newCoupon = new();
            newCoupon.couponNumber = CreateCouponNumber();
            newCoupon.couponCompany = UImethods.GetConsoleInputToRequest("Partnerunternehmen:");
            newCoupon.couponCategory = UImethods.GetConsoleInputToRequest("Rubrik:");
            newCoupon.couponBenefit = UImethods.GetConsoleInputToRequest("Vorteil:");
            newCoupon.couponDescription = UImethods.GetConsoleInputToRequest("Beschreibung");
            newCoupon.couponMaxStock = Convert.ToInt32(UImethods.GetConsoleInputToRequest("Bestand:"));
            //newCoupon.couponValidityPeriod =

            return newCoupon;
        }

        public static int CreateCouponNumber()
        {
            List<Coupon> couponList = Backup.LoadCouponRepository();

            int listNumber = couponList.Count + 1;
            int couponNumber = Convert.ToInt32(listNumber.ToString("D6"));
            return couponNumber;
        }

    }
}
