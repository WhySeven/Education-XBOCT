#pragma once
#include <list>
#include <ctime>
#include <cmath>

namespace MonteKursa {

	using namespace System;
	using namespace System::Diagnostics;
	using namespace System::ComponentModel;
	using namespace System::Collections;
	using namespace System::Windows::Forms;
	using namespace System::Data;
	using namespace System::Drawing;

	/// <summary>
	/// Сводка для MonteCarlosProc
	/// </summary>
	public ref class MonteCarlosProc : public System::Windows::Forms::Form
	{
		int n = 0;
	private: System::Windows::Forms::Label^ label1;
	private: System::Windows::Forms::RadioButton^ radioButton1;
	private: System::Windows::Forms::RadioButton^ radioButton2;
	private: System::Windows::Forms::TextBox^ textBox1;
	private: System::Windows::Forms::TextBox^ textBox2;
	private: System::Windows::Forms::TextBox^ textBox3;
	private: System::Windows::Forms::TextBox^ textBox4;
	private: System::Windows::Forms::Label^ label2;
	private: System::Windows::Forms::Label^ label3;
	private: System::Windows::Forms::Label^ label4;
	private: System::Windows::Forms::Label^ label5;
	private: System::Windows::Forms::TextBox^ textBox5;
	private: System::Windows::Forms::TextBox^ textBox6;
	private: System::Windows::Forms::Label^ label6;
			 int numberOfRow = 0;
	public:
		MonteCarlosProc(void)
		{
			InitializeComponent();
			dataGridView1->Columns->Add("№", "№");
			dataGridView1->Columns->Add("N точек, шт.", "N точек, шт.");
			dataGridView1->Columns->Add("N точек попало, шт", "N точек попало, шт");
			dataGridView1->Columns->Add("Площадь, кв. ед.", "Площадь, кв. ед.");
			dataGridView1->Columns->Add("Погрешность, %", "Погрешность, %");
			dataGridView1->Columns->Add("Время работы, мс", "Время работы, мс");
			textBox1->Text = "0";
			textBox2->Text = "14";
			textBox3->Text = "4";
			textBox4->Text = "0";
			{
				int numberOfPoints = 100;
				for (int i = 0; i < 5; i++)
				{
					dataGridView1->Rows->Add();
					dataGridView1->Rows[i]->Cells[0]->Value = i + 1;
					dataGridView1->Rows[i]->Cells[1]->Value = numberOfPoints *= 10;
				}
			}
			//dataGridView1->Rows[0]->Cells[0]->Value = "№"; // error
			//dataGridView1->Rows->Add(numberOfRow++);
			//
			//TODO: добавьте код конструктора
			//
		}

	protected:
	private:
		System::Windows::Forms::Button^ button1;
		System::Windows::Forms::Button^ button2;

	private: System::Windows::Forms::DataGridView^ dataGridView1;
			 System::Windows::Forms::PictureBox^ pictureBox2;
		/// <summary>
		/// Освободить все используемые ресурсы.
		/// </summary>
		~MonteCarlosProc()
		{
			if (components)
			{
				delete components;
			}
		}

	private:
		/// <summary>
		/// Обязательная переменная конструктора.
		/// </summary>
		System::ComponentModel::Container ^components;

#pragma region Windows Form Designer generated code
		/// <summary>
		/// Требуемый метод для поддержки конструктора — не изменяйте 
		/// содержимое этого метода с помощью редактора кода.
		/// </summary>
		void InitializeComponent(void)
		{
			System::ComponentModel::ComponentResourceManager^ resources = (gcnew System::ComponentModel::ComponentResourceManager(MonteCarlosProc::typeid));
			this->button1 = (gcnew System::Windows::Forms::Button());
			this->button2 = (gcnew System::Windows::Forms::Button());
			this->pictureBox2 = (gcnew System::Windows::Forms::PictureBox());
			this->dataGridView1 = (gcnew System::Windows::Forms::DataGridView());
			this->label1 = (gcnew System::Windows::Forms::Label());
			this->radioButton1 = (gcnew System::Windows::Forms::RadioButton());
			this->radioButton2 = (gcnew System::Windows::Forms::RadioButton());
			this->textBox1 = (gcnew System::Windows::Forms::TextBox());
			this->textBox2 = (gcnew System::Windows::Forms::TextBox());
			this->textBox3 = (gcnew System::Windows::Forms::TextBox());
			this->textBox4 = (gcnew System::Windows::Forms::TextBox());
			this->label2 = (gcnew System::Windows::Forms::Label());
			this->label3 = (gcnew System::Windows::Forms::Label());
			this->label4 = (gcnew System::Windows::Forms::Label());
			this->label5 = (gcnew System::Windows::Forms::Label());
			this->textBox5 = (gcnew System::Windows::Forms::TextBox());
			this->textBox6 = (gcnew System::Windows::Forms::TextBox());
			this->label6 = (gcnew System::Windows::Forms::Label());
			(cli::safe_cast<System::ComponentModel::ISupportInitialize^>(this->pictureBox2))->BeginInit();
			(cli::safe_cast<System::ComponentModel::ISupportInitialize^>(this->dataGridView1))->BeginInit();
			this->SuspendLayout();
			// 
			// button1
			// 
			this->button1->Location = System::Drawing::Point(652, 405);
			this->button1->Margin = System::Windows::Forms::Padding(4);
			this->button1->Name = L"button1";
			this->button1->Size = System::Drawing::Size(164, 40);
			this->button1->TabIndex = 1;
			this->button1->Text = L"Метод Монте-Карло";
			this->button1->UseVisualStyleBackColor = true;
			this->button1->Click += gcnew System::EventHandler(this, &MonteCarlosProc::button1_Click);
			// 
			// button2
			// 
			this->button2->Location = System::Drawing::Point(498, 405);
			this->button2->Margin = System::Windows::Forms::Padding(4);
			this->button2->Name = L"button2";
			this->button2->Size = System::Drawing::Size(132, 40);
			this->button2->TabIndex = 1;
			this->button2->Text = L"Кнопенский сэр";
			this->button2->UseVisualStyleBackColor = true;
			this->button2->Click += gcnew System::EventHandler(this, &MonteCarlosProc::button2_Click);
			// 
			// pictureBox2
			// 
			this->pictureBox2->BackColor = System::Drawing::Color::White;
			this->pictureBox2->Image = (cli::safe_cast<System::Drawing::Image^>(resources->GetObject(L"pictureBox2.Image")));
			this->pictureBox2->Location = System::Drawing::Point(751, 12);
			this->pictureBox2->Margin = System::Windows::Forms::Padding(4);
			this->pictureBox2->Name = L"pictureBox2";
			this->pictureBox2->Size = System::Drawing::Size(605, 267);
			this->pictureBox2->TabIndex = 2;
			this->pictureBox2->TabStop = false;
			this->pictureBox2->Click += gcnew System::EventHandler(this, &MonteCarlosProc::pictureBox2_Click);
			// 
			// dataGridView1
			// 
			this->dataGridView1->AllowUserToAddRows = false;
			this->dataGridView1->AllowUserToDeleteRows = false;
			this->dataGridView1->AutoSizeColumnsMode = System::Windows::Forms::DataGridViewAutoSizeColumnsMode::AllCells;
			this->dataGridView1->ColumnHeadersHeightSizeMode = System::Windows::Forms::DataGridViewColumnHeadersHeightSizeMode::AutoSize;
			this->dataGridView1->Location = System::Drawing::Point(12, 12);
			this->dataGridView1->Name = L"dataGridView1";
			this->dataGridView1->RowHeadersVisible = false;
			this->dataGridView1->RowTemplate->Height = 24;
			this->dataGridView1->Size = System::Drawing::Size(720, 192);
			this->dataGridView1->TabIndex = 3;
			// 
			// label1
			// 
			this->label1->AutoSize = true;
			this->label1->Location = System::Drawing::Point(603, 306);
			this->label1->Name = L"label1";
			this->label1->Size = System::Drawing::Size(129, 17);
			this->label1->TabIndex = 4;
			this->label1->Text = L"Площадь фигуры: ";
			this->label1->Click += gcnew System::EventHandler(this, &MonteCarlosProc::Label1_Click);
			// 
			// radioButton1
			// 
			this->radioButton1->AutoSize = true;
			this->radioButton1->Location = System::Drawing::Point(606, 336);
			this->radioButton1->Name = L"radioButton1";
			this->radioButton1->Size = System::Drawing::Size(110, 21);
			this->radioButton1->TabIndex = 5;
			this->radioButton1->TabStop = true;
			this->radioButton1->Text = L"radioButton1";
			this->radioButton1->UseVisualStyleBackColor = true;
			// 
			// radioButton2
			// 
			this->radioButton2->AutoSize = true;
			this->radioButton2->Location = System::Drawing::Point(606, 360);
			this->radioButton2->Name = L"radioButton2";
			this->radioButton2->Size = System::Drawing::Size(110, 21);
			this->radioButton2->TabIndex = 6;
			this->radioButton2->TabStop = true;
			this->radioButton2->Text = L"radioButton2";
			this->radioButton2->UseVisualStyleBackColor = true;
			// 
			// textBox1
			// 
			this->textBox1->Location = System::Drawing::Point(1020, 333);
			this->textBox1->Name = L"textBox1";
			this->textBox1->Size = System::Drawing::Size(111, 22);
			this->textBox1->TabIndex = 7;
			// 
			// textBox2
			// 
			this->textBox2->Location = System::Drawing::Point(1020, 361);
			this->textBox2->Name = L"textBox2";
			this->textBox2->Size = System::Drawing::Size(111, 22);
			this->textBox2->TabIndex = 8;
			// 
			// textBox3
			// 
			this->textBox3->Location = System::Drawing::Point(1151, 333);
			this->textBox3->Name = L"textBox3";
			this->textBox3->Size = System::Drawing::Size(111, 22);
			this->textBox3->TabIndex = 9;
			// 
			// textBox4
			// 
			this->textBox4->Location = System::Drawing::Point(1151, 361);
			this->textBox4->Name = L"textBox4";
			this->textBox4->Size = System::Drawing::Size(111, 22);
			this->textBox4->TabIndex = 10;
			// 
			// label2
			// 
			this->label2->AutoSize = true;
			this->label2->Location = System::Drawing::Point(1017, 304);
			this->label2->Name = L"label2";
			this->label2->Size = System::Drawing::Size(105, 17);
			this->label2->TabIndex = 11;
			this->label2->Text = L"Координата Х:";
			this->label2->Click += gcnew System::EventHandler(this, &MonteCarlosProc::Label2_Click);
			// 
			// label3
			// 
			this->label3->AutoSize = true;
			this->label3->Location = System::Drawing::Point(1153, 304);
			this->label3->Name = L"label3";
			this->label3->Size = System::Drawing::Size(109, 17);
			this->label3->TabIndex = 12;
			this->label3->Text = L"Координата Y: ";
			// 
			// label4
			// 
			this->label4->AutoSize = true;
			this->label4->Location = System::Drawing::Point(950, 336);
			this->label4->Name = L"label4";
			this->label4->Size = System::Drawing::Size(64, 17);
			this->label4->TabIndex = 13;
			this->label4->Text = L"Точка b:";
			// 
			// label5
			// 
			this->label5->AutoSize = true;
			this->label5->Location = System::Drawing::Point(950, 364);
			this->label5->Name = L"label5";
			this->label5->Size = System::Drawing::Size(68, 17);
			this->label5->TabIndex = 14;
			this->label5->Text = L"Точка d: ";
			this->label5->Click += gcnew System::EventHandler(this, &MonteCarlosProc::Label5_Click);
			// 
			// textBox5
			// 
			this->textBox5->Location = System::Drawing::Point(1020, 389);
			this->textBox5->Name = L"textBox5";
			this->textBox5->Size = System::Drawing::Size(111, 22);
			this->textBox5->TabIndex = 15;
			// 
			// textBox6
			// 
			this->textBox6->Location = System::Drawing::Point(1151, 389);
			this->textBox6->Name = L"textBox6";
			this->textBox6->Size = System::Drawing::Size(111, 22);
			this->textBox6->TabIndex = 16;
			// 
			// label6
			// 
			this->label6->AutoSize = true;
			this->label6->Location = System::Drawing::Point(950, 392);
			this->label6->Name = L"label6";
			this->label6->Size = System::Drawing::Size(68, 17);
			this->label6->TabIndex = 17;
			this->label6->Text = L"Точка e: ";
			// 
			// MonteCarlosProc
			// 
			this->AutoScaleDimensions = System::Drawing::SizeF(8, 16);
			this->AutoScaleMode = System::Windows::Forms::AutoScaleMode::Font;
			this->ClientSize = System::Drawing::Size(1367, 611);
			this->Controls->Add(this->label6);
			this->Controls->Add(this->textBox6);
			this->Controls->Add(this->textBox5);
			this->Controls->Add(this->label5);
			this->Controls->Add(this->label4);
			this->Controls->Add(this->label3);
			this->Controls->Add(this->label2);
			this->Controls->Add(this->textBox4);
			this->Controls->Add(this->textBox3);
			this->Controls->Add(this->textBox2);
			this->Controls->Add(this->textBox1);
			this->Controls->Add(this->radioButton2);
			this->Controls->Add(this->radioButton1);
			this->Controls->Add(this->label1);
			this->Controls->Add(this->dataGridView1);
			this->Controls->Add(this->button1);
			this->Controls->Add(this->button2);
			this->Controls->Add(this->pictureBox2);
			this->DoubleBuffered = true;
			this->Margin = System::Windows::Forms::Padding(4);
			this->Name = L"MonteCarlosProc";
			this->Text = L"Низвержение с Олимпа";
			(cli::safe_cast<System::ComponentModel::ISupportInitialize^>(this->pictureBox2))->EndInit();
			(cli::safe_cast<System::ComponentModel::ISupportInitialize^>(this->dataGridView1))->EndInit();
			this->ResumeLayout(false);
			this->PerformLayout();

		}
#pragma endregion
		System::Void button1_Click(System::Object^ sender, System::EventArgs^ e)
		{
			// params for b and d points
			int b_x = System::Convert::ToInt32(textBox1->Text); // change for cpp-style
			int b_y = System::Convert::ToInt32(textBox3->Text);
			int d_x = System::Convert::ToInt32(textBox2->Text);
			int d_y = System::Convert::ToInt32(textBox4->Text);
			// end point's params
			// square params
			int f_x = d_x - 2*b_y;
			int f_y = d_y;

			int o_x = d_x-b_y;
			int o_y = d_y;

			int e_y = b_y;
			int e_x = d_x - b_y;
			
			int k = e_y - b_y;
			int b;

			double full_square = (double)((b_y - d_y) * (d_x - b_x));
			int iterator = 0;
			// end square params
			//int numberPoints;
			for(long rowsIterator = 0; rowsIterator < dataGridView1->Rows->Count; rowsIterator++) // dataGridView1->Rows->Count
			{
				//long rowsIterator = 1;
				auto time = std::clock();
				int numberPoints = System::Convert::ToInt32(dataGridView1->Rows[rowsIterator]->Cells[1]->Value);
				System::Collections::Generic::List<int> in_np;
				for (int i = 0; i < numberPoints; i++) // find second column values
				{
					int p_x = getRandomNumber(b_x, d_x);
					int p_y = getRandomNumber(b_y, d_y);
					// generate random point
					if (p_x >= b_x
						&& p_y >= (((p_x - f_x) * (b_y - f_y) / (b_x - f_x)) + f_y)//(p_x - b_x)*((f_y - b_y)/(f_x-b_x)) + b_y//((p_x - f_x)*(b_y-f_y)/(b_x-f_x)) + f_y // деление на 0
						&& (pow((p_x - o_x), 2) + (pow(p_y - o_y,2))) <= pow((e_y - d_y), 2)) // y_bf() + R_o // fix this shit
					{
						iterator++;
					}
				}
				//auto time_end = std::clock();
				dataGridView1->Rows[rowsIterator]->Cells[2]->Value = iterator;
				dataGridView1->Rows[rowsIterator]->Cells[3]->Value = (double)((full_square)*iterator/numberPoints); // square
				dataGridView1->Rows[rowsIterator]->Cells[4]->Value = std::abs(1 - ((double)(full_square * (iterator) / numberPoints))/full_square) * 100;// погрешность = 0?
				dataGridView1->Rows[rowsIterator]->Cells[5]->Value = (clock() - time); // working time
			}
			System::Windows::Forms::MessageBox::Show("Площадь фигуры равна " + (full_square-(pow(b_y,2) * (1 - 3.14/4) + (b_y*f_x/2)))); // define pi // finished without define
		}
		System::Void button2_Click(System::Object^ sender, System::EventArgs^ e)
		{
			this->Close();
		}
		int getRandomNumber(int min, int max)
		{
			static const double fraction = 1.0 / (static_cast<double>(RAND_MAX) + 1.0);
			return static_cast<int>(rand() * fraction * (max - min));
		}
		/*
		public bool isInsideCircularArc(double x, double y)
		{
			return (((x - _oPointX) * (x - _oPointX) + (y - _oPointY) * (y - _oPointY)) <= _radius * _radius) ? true : false;
		}
		*/
		System::Void pictureBox1_Click(System::Object^ sender, System::EventArgs^ e)
		{

		}
		System::Void pictureBox2_Click(System::Object^ sender, System::EventArgs^ e)
		{

		}
		private: System::Void Label1_Click(System::Object^ sender, System::EventArgs^ e) {
		}
		private: System::Void Label2_Click(System::Object^ sender, System::EventArgs^ e) {
		}
		private: System::Void Label5_Click(System::Object^ sender, System::EventArgs^ e) {
		}
	};
}
