namespace CatchButton
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_MouseEnter(object sender, EventArgs e)
        {
         
            // 1. 난수생성기준비
            Random rd= new Random();

            // 2. 가용영역계산(버튼이폼테두리에걸리지않게보호)
            // ClientSize는타이틀바와테두리를제외한실제흰도화지영역임
            int maxX= this.ClientSize.Width;int maxY= this.ClientSize.Height;

            // 3. 랜덤좌표추출(0 ~ 최대가용치사이)
            // 버튼의 좌표 기준이 좌상단에 있기 때문에 form밖으로 잘려나오는 경우 생김 그래서 버튼의 크기만큼 빼줌
            int nextX = rd.Next(0, maxX-RunButton.Size.Width);
            int nextY= rd.Next(0, maxY-RunButton.Size.Height);

            // 4. 위치할당(새로운Point 객체생성)
            RunButton.Location= new Point(nextX, nextY);
            
            // 5. 시각적피드백(폼제목표시줄에좌표출력)
            this.Text= $"버튼위치: ({nextX}, {nextY})";

        }
    }
}
