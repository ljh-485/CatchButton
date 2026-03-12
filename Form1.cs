using System.Media;
using System.Drawing;
using System.Windows.Forms;

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
        Random rnd = new Random();

        public Form1()
        {
            InitializeComponent();
            // 초기 폼 제목에 점수 표시
            this.Text = $"점수: {score}";

            // 원래 버튼 크기 저장
            originalButtonSize = RunButton.Size;
            // 원래 버튼 폰트 저장
            originalButtonFont = RunButton.Font;
            originalFontSize = RunButton.Font.Size;
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
            // 버튼 폰트도 스케일에 맞춰 조정
            float newFontSize = Math.Max(1f, (float)Math.Round(originalFontSize * (float)currentScale, 1));
            RunButton.Font = new Font(originalButtonFont.FontFamily, newFontSize, originalButtonFont.Style);
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
            missCount++;
            SystemSounds.Exclamation.Play(); // 놓쳤을 때

            // 게임 오버 조건 검사
            if (missCount >= maxMisses)
            {
                var result = MessageBox.Show(
                    "게임 오버! 다시 시작하시겠습니까?",
                    "Game Over",
                    MessageBoxButtons.RetryCancel,
                    MessageBoxIcon.Question,
                    MessageBoxDefaultButton.Button1);

                if (result == DialogResult.Retry)
                {
                    // 다시 시작
                    ResetGame();
                    return;
                }
                else
                {
                    // 확인(또는 취소): 모든 버튼 비활성화
                    foreach (Control c in this.Controls)
                    {
                        if (c is Button btn)
                            btn.Enabled = false;
                    }
                    return;
                }
            }

            // 2. 가용영역계산(버튼이 폼 테두리에 걸리지 않게 보호)
            int maxX = Math.Max(0, this.ClientSize.Width - RunButton.Size.Width);
            int maxY = Math.Max(0, this.ClientSize.Height - RunButton.Size.Height);

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

        // 게임을 초기 상태로 리셋
        private void ResetGame()
        {
            score = 1000;
            missCount = 0;
            currentScale = 1.0;
            // 되돌리기: 버튼 크기 및 폰트
            RunButton.Size = originalButtonSize;
            RunButton.Font = originalButtonFont;
            RunButton.Enabled = true;
            // 제목 갱신
            this.Text = $"점수: {score}";
        }
    }
}
