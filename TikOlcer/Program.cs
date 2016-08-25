using System;
using System.Drawing;

using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Events;

namespace TikOlcer
{
    internal static class Program
    {
        private static int Clicks;

        private static void Main(string[] args)
        {
            Loading.OnLoadingComplete += Loading_OnLoadingComplete;
        }

        private static void Loading_OnLoadingComplete(EventArgs args)
        {
            Player.OnIssueOrder += Player_OnIssueOrder;
            Drawing.OnDraw += Drawing_OnDraw;
        }

        private static void Player_OnIssueOrder(Obj_AI_Base sender, PlayerIssueOrderEventArgs args)
        {
            if (sender.IsMe && (args.Order.HasFlag(GameObjectOrder.MoveTo) || args.Order.HasFlag(GameObjectOrder.AttackTo)))
            {
                Clicks++;
            }
        }

        private static void Drawing_OnDraw(EventArgs args)
        {
            Drawing.DrawText(Drawing.Height * 0.1f, Drawing.Width * 0.1f, Color.GreenYellow, $"Tıklamalar: {Clicks}");
        }
    }
}
