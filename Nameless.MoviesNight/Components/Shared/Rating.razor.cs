using Microsoft.AspNetCore.Components;

namespace Nameless.MoviesNight.Components.Shared {
    public partial class Rating {
        private int _stars = 10;

        [Parameter]
        public decimal ActualScore { get; set; }

        [Parameter]
        public decimal MaxScore { get; set; } = 10m;

        [Parameter]
        public int Stars {
            get => _stars;
            set => _stars = value < 0 ? 10 : value;
        }

        private decimal Multiplier => MaxScore > Stars
            ? MaxScore / Stars
            : Stars / MaxScore;

        public string AddChecked(int star) {
            var score = star * Multiplier;

            return score <= ActualScore ? "checked" : string.Empty;
        }

        public string GetScoreRepresentation()
            => $"{ActualScore:F2} / {MaxScore:F2}";
    }
}
