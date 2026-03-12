using System.Media;
using System.Drawing;

namespace CatchButton
{
    public partial class Form1 : Form
    {
        // 현재 점수
        private int score = 1000;
        // 버튼 크기 조절 관련
        private Size originalButtonSize;
        private double currentScale = 1.0; // 현재 크기 비율(원래 크기 대비)
        private const double minScale = 0.8;   // 최소 80%까지
        // 버튼 폰트 원래 크기 저장
        private Font originalButtonFont;
        private float originalFontSize;
        // 놓친 횟수
        private int missCount = 0;
        private const int maxMisses = 30;

        public Form1()
        {
            InitializeComponent();
            // 초기 폼 제목에 점수 표시
            this.Text = $"점수: {score}";

            // 원래 버튼 크기 저장
            originalButtonSize = RunButton.Size;
        }

        // 버튼을 일정 비율만큼 줄임(예: 0.1 = 10%)
        private void ShrinkButtonByPercentage(double fraction)
        {
            if (fraction <= 0) return;
            // 다음 스케일 계산(곱셈식으로 누적)
            double nextScale = currentScale * (1.0 - fraction);
            if (nextScale < minScale) nextScale = minScale;
            if (nextScale == currentScale) return; // 더 이상 줄이지 않음

            currentScale = nextScale;
            int newW = Math.Max(1, (int)Math.Round(originalButtonSize.Width * currentScale));
            int newH = Math.Max(1, (int)Math.Round(originalButtonSize.Height * currentScale));
            RunButton.Size = new Size(newW, newH);
        }

        // 점수 변경 및 최소 0점 고정, 폼 제목에 점수 표시
        private void ChangeScore(int delta)
        {
            score += delta;
            if (score < 0) score = 0; // 최소 0점 고정
            this.Text = $"점수: {score}";
        }

        // 버튼을 잡았을 때
        private void RunButton_MouseClick(object sender, MouseEventArgs e)
        {
            SystemSounds.Beep.Play(); // 기존 소리
            // 점수 추가(잡았을 때 100점)
            ChangeScore(100);

            // 버튼을 10% 줄임(최소 80%까지)
            ShrinkButtonByPercentage(0.10);

            MessageBox.Show("축하합니다~!", "성공", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void RunButton_MouseEnter(object sender, EventArgs e)
        {
            // 놓쳤을 때 점수 감점(10점) 및 최소 0점 고정
            ChangeScore(-10);
            SystemSounds.Exclamation.Play(); // 놓쳤을 때

            // 게임 오버 조건 검사
            if (missCount >= maxMisses)
            {
                using (var dlg = new GameOverForm())
                {
                    dlg.ShowDialog(this);
                    if (dlg.RestartClicked)
                    {
                        // 다시 시작
                        ResetGame();
                        return;
                    }
                    else
                    {
                        // 확인: 모든 버튼 비활성화
                        foreach (Control c in this.Controls)
                        {
                            if (c is Button btn)
                                btn.Enabled = false;
                        }
                        return;
                    }
                }
            }

            // 1. 난수생성기준비
            Random rd = new Random();

            // 2. 가용영역계산(버튼이폼테두리에걸리지않게보호)
            // ClientSize는타이틀바와테두리를제외한실제흰도화지영역임
            int maxX = this.ClientSize.Width; int maxY = this.ClientSize.Height;

            // 3. 랜덤좌표추출(0 ~ 최대가용치 사이)
            int nextX = rnd.Next(0, Math.Max(1, maxX + 1));
            int nextY = rnd.Next(0, Math.Max(1, maxY + 1));

            // 4. 위치할당
            RunButton.Location = new Point(nextX, nextY);

            // 5. 시각적 피드백(폼 제목 표시줄에 좌표 출력)
            this.Text = $"점수: {score}    버튼위치: ({nextX}, {nextY})";
        }

        private void RunButton_Click(object sender, EventArgs e)
        {

        }
    }
}
