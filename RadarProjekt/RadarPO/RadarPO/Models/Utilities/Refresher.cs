using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using RadarPO.Models;
using RadarPO;
namespace RadarPO.Models.Utilities
{
    class Refresher
    {

        static Boolean IsEnabled = false;
        static CancellationTokenSource token = new CancellationTokenSource();

        public static async Task Periodic(Action func, TimeSpan period, CancellationToken token)
        {
            try
            {
                IsEnabled = true;
                while (true)
                {

                    token.ThrowIfCancellationRequested();
                    func();

                    await Task.Delay(period);

                }
            }
            catch (OperationCanceledException e)
            { IsEnabled = false; }
        }


        public async void Start(Radar radar)
        {
            if (IsEnabled == false)
            {
                token.Dispose();
                token = new CancellationTokenSource();

                await Periodic(() => { radar.Sync(); }, TimeSpan.FromSeconds(0.0005), token.Token);
            }
        }

        public void Stop() => token.Cancel();
    }

}
