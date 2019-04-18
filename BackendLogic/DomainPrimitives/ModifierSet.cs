using RPSBackendLogic.ValueObjects;
using System;


namespace RPSBackendLogic.DomainPrimitives
{

    public sealed class ModifierSet
    {
        private readonly Quantity rkVsSs;
        private readonly Quantity rkVsPp;
        private readonly Quantity ssVsRk;
        private readonly Quantity ssVsPp;
        private readonly Quantity ppVsRk;
        private readonly Quantity ppVsSs;

        private bool RkVsSsFlag = false;
        private bool RkVsPpFlag = false;
        private bool SsVsRkFlag = false;
        private bool SsVsPpFlag = false;
        private bool PpVsRkFlag = false;
        private bool PpVsSsFlag = false;


        public Quantity RkVsSs { get { return ReadOnceItem(ref RkVsSsFlag, rkVsSs); } }
        public Quantity RkVsPp { get { return ReadOnceItem(ref RkVsPpFlag, rkVsPp); } }
        public Quantity SsVsRk { get { return ReadOnceItem(ref SsVsRkFlag, ssVsRk); } }
        public Quantity SsVsPp { get { return ReadOnceItem(ref SsVsPpFlag, ssVsPp); } }
        public Quantity PpVsRk { get { return ReadOnceItem(ref PpVsRkFlag, ppVsRk); } }
        public Quantity PpVsSs { get { return ReadOnceItem(ref PpVsSsFlag, ppVsSs); } }

        public ModifierSet(Quantity rkss, Quantity rkpp, Quantity ssrk, Quantity sspp, Quantity pprk, Quantity ppss)
        {
            rkVsSs = rkss;
            rkVsPp = rkpp;
            ssVsRk = ssrk;
            ssVsPp = sspp;
            ppVsRk = pprk;
            ppVsSs = ppss;
        }

        private Quantity ReadOnceItem(ref bool flag, Quantity value)
        {
            if (!flag)
            {
                flag = true;
                return value;
            }
            throw new Exception("You cannot read this field twice.");
        }
    }
}
