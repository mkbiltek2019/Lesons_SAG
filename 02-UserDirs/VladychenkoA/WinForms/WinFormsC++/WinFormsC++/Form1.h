#pragma once

#include <time.h>
#include <string>
namespace WinFormsC {

	using namespace System;
	using namespace System::ComponentModel;
	using namespace System::Collections;
	using namespace System::Windows::Forms;
	using namespace System::Data;
	using namespace System::Drawing;

	/// <summary>
	/// Сводка для Form1
	///
	/// Внимание! При изменении имени этого класса необходимо также изменить
	///          свойство имени файла ресурсов ("Resource File Name") для средства компиляции управляемого ресурса,
	///          связанного со всеми файлами с расширением .resx, от которых зависит данный класс. В противном случае,
	///          конструкторы не смогут правильно работать с локализованными
	///          ресурсами, сопоставленными данной форме.
	/// </summary>
	public enum DayOfTheWeek { Воскресение ,Понедельник, Вторник, Среда, Четверг, Пятница, Субота };
	public ref class Form1 : public System::Windows::Forms::Form
	{
	public:
		Form1(void)
		{
			InitializeComponent();
			//
			//TODO: добавьте код конструктора
			//
			
			
		}

	protected:
		/// <summary>
		/// Освободить все используемые ресурсы.
		/// </summary>
		~Form1()
		{
			if (components)
			{
				delete components;
			}
		}
	private: System::Windows::Forms::Label^  label1;
	private: System::Windows::Forms::Timer^  timer1;
	private: System::Windows::Forms::Button^  button1;
	private: System::Windows::Forms::MenuStrip^  menuStrip1;
	private: System::Windows::Forms::ToolStripMenuItem^  файлToolStripMenuItem;
	private: System::Windows::Forms::ToolStripMenuItem^  создатьToolStripMenuItem;
	private: System::Windows::Forms::ToolStripMenuItem^  открытьToolStripMenuItem;
	private: System::Windows::Forms::ToolStripSeparator^  toolStripSeparator;
	private: System::Windows::Forms::ToolStripMenuItem^  сохранитьToolStripMenuItem;
	private: System::Windows::Forms::ToolStripMenuItem^  сохранитькакToolStripMenuItem;
	private: System::Windows::Forms::ToolStripSeparator^  toolStripSeparator1;
	private: System::Windows::Forms::ToolStripMenuItem^  печатьToolStripMenuItem;
	private: System::Windows::Forms::ToolStripMenuItem^  предварительныйпросмотрToolStripMenuItem;
	private: System::Windows::Forms::ToolStripSeparator^  toolStripSeparator2;
	private: System::Windows::Forms::ToolStripMenuItem^  выходToolStripMenuItem;
	private: System::Windows::Forms::ToolStripMenuItem^  правкаToolStripMenuItem;
	private: System::Windows::Forms::ToolStripMenuItem^  отменадействияToolStripMenuItem;
	private: System::Windows::Forms::ToolStripMenuItem^  отменадействияToolStripMenuItem1;
	private: System::Windows::Forms::ToolStripSeparator^  toolStripSeparator3;
	private: System::Windows::Forms::ToolStripMenuItem^  вырезатьToolStripMenuItem;
	private: System::Windows::Forms::ToolStripMenuItem^  копироватьToolStripMenuItem;
	private: System::Windows::Forms::ToolStripMenuItem^  вставкаToolStripMenuItem;
	private: System::Windows::Forms::ToolStripSeparator^  toolStripSeparator4;
	private: System::Windows::Forms::ToolStripMenuItem^  выделитьвсеToolStripMenuItem;
	private: System::Windows::Forms::ToolStripMenuItem^  сервисToolStripMenuItem;
	private: System::Windows::Forms::ToolStripMenuItem^  настройкиToolStripMenuItem;
	private: System::Windows::Forms::ToolStripMenuItem^  параметрыToolStripMenuItem;
	private: System::Windows::Forms::ToolStripMenuItem^  справкаToolStripMenuItem;
	private: System::Windows::Forms::ToolStripMenuItem^  содержаниеToolStripMenuItem;
	private: System::Windows::Forms::ToolStripMenuItem^  индексToolStripMenuItem;
	private: System::Windows::Forms::ToolStripMenuItem^  поискToolStripMenuItem;
	private: System::Windows::Forms::ToolStripSeparator^  toolStripSeparator5;
	private: System::Windows::Forms::ToolStripMenuItem^  опрограммеToolStripMenuItem;
	private: System::Windows::Forms::Label^  label2;


	private: System::Windows::Forms::Label^  label3;
	private: System::Windows::Forms::Label^  label4;
	private: System::Windows::Forms::Label^  labelDay;

	private: System::ComponentModel::IContainer^  components;
	protected: 

	private:
		/// <summary>
		/// Требуется переменная конструктора.
		/// </summary>


#pragma region Windows Form Designer generated code
		/// <summary>
		/// Обязательный метод для поддержки конструктора - не изменяйте
		/// содержимое данного метода при помощи редактора кода.
		/// </summary>
		void InitializeComponent(void)
		{
			this->components = (gcnew System::ComponentModel::Container());
			System::ComponentModel::ComponentResourceManager^  resources = (gcnew System::ComponentModel::ComponentResourceManager(Form1::typeid));
			this->label1 = (gcnew System::Windows::Forms::Label());
			this->timer1 = (gcnew System::Windows::Forms::Timer(this->components));
			this->button1 = (gcnew System::Windows::Forms::Button());
			this->menuStrip1 = (gcnew System::Windows::Forms::MenuStrip());
			this->файлToolStripMenuItem = (gcnew System::Windows::Forms::ToolStripMenuItem());
			this->создатьToolStripMenuItem = (gcnew System::Windows::Forms::ToolStripMenuItem());
			this->открытьToolStripMenuItem = (gcnew System::Windows::Forms::ToolStripMenuItem());
			this->toolStripSeparator = (gcnew System::Windows::Forms::ToolStripSeparator());
			this->сохранитьToolStripMenuItem = (gcnew System::Windows::Forms::ToolStripMenuItem());
			this->сохранитькакToolStripMenuItem = (gcnew System::Windows::Forms::ToolStripMenuItem());
			this->toolStripSeparator1 = (gcnew System::Windows::Forms::ToolStripSeparator());
			this->печатьToolStripMenuItem = (gcnew System::Windows::Forms::ToolStripMenuItem());
			this->предварительныйпросмотрToolStripMenuItem = (gcnew System::Windows::Forms::ToolStripMenuItem());
			this->toolStripSeparator2 = (gcnew System::Windows::Forms::ToolStripSeparator());
			this->выходToolStripMenuItem = (gcnew System::Windows::Forms::ToolStripMenuItem());
			this->правкаToolStripMenuItem = (gcnew System::Windows::Forms::ToolStripMenuItem());
			this->отменадействияToolStripMenuItem = (gcnew System::Windows::Forms::ToolStripMenuItem());
			this->отменадействияToolStripMenuItem1 = (gcnew System::Windows::Forms::ToolStripMenuItem());
			this->toolStripSeparator3 = (gcnew System::Windows::Forms::ToolStripSeparator());
			this->вырезатьToolStripMenuItem = (gcnew System::Windows::Forms::ToolStripMenuItem());
			this->копироватьToolStripMenuItem = (gcnew System::Windows::Forms::ToolStripMenuItem());
			this->вставкаToolStripMenuItem = (gcnew System::Windows::Forms::ToolStripMenuItem());
			this->toolStripSeparator4 = (gcnew System::Windows::Forms::ToolStripSeparator());
			this->выделитьвсеToolStripMenuItem = (gcnew System::Windows::Forms::ToolStripMenuItem());
			this->сервисToolStripMenuItem = (gcnew System::Windows::Forms::ToolStripMenuItem());
			this->настройкиToolStripMenuItem = (gcnew System::Windows::Forms::ToolStripMenuItem());
			this->параметрыToolStripMenuItem = (gcnew System::Windows::Forms::ToolStripMenuItem());
			this->справкаToolStripMenuItem = (gcnew System::Windows::Forms::ToolStripMenuItem());
			this->содержаниеToolStripMenuItem = (gcnew System::Windows::Forms::ToolStripMenuItem());
			this->индексToolStripMenuItem = (gcnew System::Windows::Forms::ToolStripMenuItem());
			this->поискToolStripMenuItem = (gcnew System::Windows::Forms::ToolStripMenuItem());
			this->toolStripSeparator5 = (gcnew System::Windows::Forms::ToolStripSeparator());
			this->опрограммеToolStripMenuItem = (gcnew System::Windows::Forms::ToolStripMenuItem());
			this->label2 = (gcnew System::Windows::Forms::Label());
			this->label3 = (gcnew System::Windows::Forms::Label());
			this->label4 = (gcnew System::Windows::Forms::Label());
			this->labelDay = (gcnew System::Windows::Forms::Label());
			this->menuStrip1->SuspendLayout();
			this->SuspendLayout();
			// 
			// label1
			// 
			this->label1->Font = (gcnew System::Drawing::Font(L"Microsoft Sans Serif", 27.75F, System::Drawing::FontStyle::Regular, System::Drawing::GraphicsUnit::Point, 
				static_cast<System::Byte>(204)));
			this->label1->Location = System::Drawing::Point(55, 50);
			this->label1->Name = L"label1";
			this->label1->Size = System::Drawing::Size(180, 41);
			this->label1->TabIndex = 0;
			this->label1->Text = L"12:00:00";
			this->label1->TextAlign = System::Drawing::ContentAlignment::MiddleCenter;
			// 
			// timer1
			// 
			this->timer1->Tick += gcnew System::EventHandler(this, &Form1::timer1_Tick);
			// 
			// button1
			// 
			this->button1->ForeColor = System::Drawing::Color::Navy;
			this->button1->Location = System::Drawing::Point(110, 94);
			this->button1->Name = L"button1";
			this->button1->Size = System::Drawing::Size(75, 23);
			this->button1->TabIndex = 1;
			this->button1->Text = L"Пуск";
			this->button1->UseVisualStyleBackColor = true;
			this->button1->Click += gcnew System::EventHandler(this, &Form1::button1_Click);
			// 
			// menuStrip1
			// 
			this->menuStrip1->Items->AddRange(gcnew cli::array< System::Windows::Forms::ToolStripItem^  >(4) {this->файлToolStripMenuItem, 
				this->правкаToolStripMenuItem, this->сервисToolStripMenuItem, this->справкаToolStripMenuItem});
			this->menuStrip1->Location = System::Drawing::Point(0, 0);
			this->menuStrip1->Name = L"menuStrip1";
			this->menuStrip1->Size = System::Drawing::Size(284, 24);
			this->menuStrip1->TabIndex = 2;
			this->menuStrip1->Text = L"menuStrip1";
			// 
			// файлToolStripMenuItem
			// 
			this->файлToolStripMenuItem->DropDownItems->AddRange(gcnew cli::array< System::Windows::Forms::ToolStripItem^  >(10) {this->создатьToolStripMenuItem, 
				this->открытьToolStripMenuItem, this->toolStripSeparator, this->сохранитьToolStripMenuItem, this->сохранитькакToolStripMenuItem, 
				this->toolStripSeparator1, this->печатьToolStripMenuItem, this->предварительныйпросмотрToolStripMenuItem, this->toolStripSeparator2, 
				this->выходToolStripMenuItem});
			this->файлToolStripMenuItem->Name = L"файлToolStripMenuItem";
			this->файлToolStripMenuItem->Size = System::Drawing::Size(48, 20);
			this->файлToolStripMenuItem->Text = L"&Файл";
			// 
			// создатьToolStripMenuItem
			// 
			this->создатьToolStripMenuItem->Image = (cli::safe_cast<System::Drawing::Image^  >(resources->GetObject(L"создатьToolStripMenuItem.Image")));
			this->создатьToolStripMenuItem->ImageTransparentColor = System::Drawing::Color::Magenta;
			this->создатьToolStripMenuItem->Name = L"создатьToolStripMenuItem";
			this->создатьToolStripMenuItem->ShortcutKeys = static_cast<System::Windows::Forms::Keys>((System::Windows::Forms::Keys::Control | System::Windows::Forms::Keys::N));
			this->создатьToolStripMenuItem->Size = System::Drawing::Size(233, 22);
			this->создатьToolStripMenuItem->Text = L"&Создать";
			// 
			// открытьToolStripMenuItem
			// 
			this->открытьToolStripMenuItem->Image = (cli::safe_cast<System::Drawing::Image^  >(resources->GetObject(L"открытьToolStripMenuItem.Image")));
			this->открытьToolStripMenuItem->ImageTransparentColor = System::Drawing::Color::Magenta;
			this->открытьToolStripMenuItem->Name = L"открытьToolStripMenuItem";
			this->открытьToolStripMenuItem->ShortcutKeys = static_cast<System::Windows::Forms::Keys>((System::Windows::Forms::Keys::Control | System::Windows::Forms::Keys::O));
			this->открытьToolStripMenuItem->Size = System::Drawing::Size(233, 22);
			this->открытьToolStripMenuItem->Text = L"&Открыть";
			// 
			// toolStripSeparator
			// 
			this->toolStripSeparator->Name = L"toolStripSeparator";
			this->toolStripSeparator->Size = System::Drawing::Size(230, 6);
			// 
			// сохранитьToolStripMenuItem
			// 
			this->сохранитьToolStripMenuItem->Image = (cli::safe_cast<System::Drawing::Image^  >(resources->GetObject(L"сохранитьToolStripMenuItem.Image")));
			this->сохранитьToolStripMenuItem->ImageTransparentColor = System::Drawing::Color::Magenta;
			this->сохранитьToolStripMenuItem->Name = L"сохранитьToolStripMenuItem";
			this->сохранитьToolStripMenuItem->ShortcutKeys = static_cast<System::Windows::Forms::Keys>((System::Windows::Forms::Keys::Control | System::Windows::Forms::Keys::S));
			this->сохранитьToolStripMenuItem->Size = System::Drawing::Size(233, 22);
			this->сохранитьToolStripMenuItem->Text = L"&Сохранить";
			// 
			// сохранитькакToolStripMenuItem
			// 
			this->сохранитькакToolStripMenuItem->Name = L"сохранитькакToolStripMenuItem";
			this->сохранитькакToolStripMenuItem->Size = System::Drawing::Size(233, 22);
			this->сохранитькакToolStripMenuItem->Text = L"Сохранить &как";
			// 
			// toolStripSeparator1
			// 
			this->toolStripSeparator1->Name = L"toolStripSeparator1";
			this->toolStripSeparator1->Size = System::Drawing::Size(230, 6);
			// 
			// печатьToolStripMenuItem
			// 
			this->печатьToolStripMenuItem->Image = (cli::safe_cast<System::Drawing::Image^  >(resources->GetObject(L"печатьToolStripMenuItem.Image")));
			this->печатьToolStripMenuItem->ImageTransparentColor = System::Drawing::Color::Magenta;
			this->печатьToolStripMenuItem->Name = L"печатьToolStripMenuItem";
			this->печатьToolStripMenuItem->ShortcutKeys = static_cast<System::Windows::Forms::Keys>((System::Windows::Forms::Keys::Control | System::Windows::Forms::Keys::P));
			this->печатьToolStripMenuItem->Size = System::Drawing::Size(233, 22);
			this->печатьToolStripMenuItem->Text = L"&Печать";
			// 
			// предварительныйпросмотрToolStripMenuItem
			// 
			this->предварительныйпросмотрToolStripMenuItem->Image = (cli::safe_cast<System::Drawing::Image^  >(resources->GetObject(L"предварительныйпросмотрToolStripMenuItem.Image")));
			this->предварительныйпросмотрToolStripMenuItem->ImageTransparentColor = System::Drawing::Color::Magenta;
			this->предварительныйпросмотрToolStripMenuItem->Name = L"предварительныйпросмотрToolStripMenuItem";
			this->предварительныйпросмотрToolStripMenuItem->Size = System::Drawing::Size(233, 22);
			this->предварительныйпросмотрToolStripMenuItem->Text = L"Предварительный про&смотр";
			// 
			// toolStripSeparator2
			// 
			this->toolStripSeparator2->Name = L"toolStripSeparator2";
			this->toolStripSeparator2->Size = System::Drawing::Size(230, 6);
			// 
			// выходToolStripMenuItem
			// 
			this->выходToolStripMenuItem->Name = L"выходToolStripMenuItem";
			this->выходToolStripMenuItem->Size = System::Drawing::Size(233, 22);
			this->выходToolStripMenuItem->Text = L"Вы&ход";
			// 
			// правкаToolStripMenuItem
			// 
			this->правкаToolStripMenuItem->DropDownItems->AddRange(gcnew cli::array< System::Windows::Forms::ToolStripItem^  >(8) {this->отменадействияToolStripMenuItem, 
				this->отменадействияToolStripMenuItem1, this->toolStripSeparator3, this->вырезатьToolStripMenuItem, this->копироватьToolStripMenuItem, 
				this->вставкаToolStripMenuItem, this->toolStripSeparator4, this->выделитьвсеToolStripMenuItem});
			this->правкаToolStripMenuItem->Name = L"правкаToolStripMenuItem";
			this->правкаToolStripMenuItem->Size = System::Drawing::Size(59, 20);
			this->правкаToolStripMenuItem->Text = L"&Правка";
			// 
			// отменадействияToolStripMenuItem
			// 
			this->отменадействияToolStripMenuItem->Name = L"отменадействияToolStripMenuItem";
			this->отменадействияToolStripMenuItem->ShortcutKeys = static_cast<System::Windows::Forms::Keys>((System::Windows::Forms::Keys::Control | System::Windows::Forms::Keys::Z));
			this->отменадействияToolStripMenuItem->Size = System::Drawing::Size(209, 22);
			this->отменадействияToolStripMenuItem->Text = L"&Отмена действия";
			// 
			// отменадействияToolStripMenuItem1
			// 
			this->отменадействияToolStripMenuItem1->Name = L"отменадействияToolStripMenuItem1";
			this->отменадействияToolStripMenuItem1->ShortcutKeys = static_cast<System::Windows::Forms::Keys>((System::Windows::Forms::Keys::Control | System::Windows::Forms::Keys::Y));
			this->отменадействияToolStripMenuItem1->Size = System::Drawing::Size(209, 22);
			this->отменадействияToolStripMenuItem1->Text = L"&Отмена действия";
			// 
			// toolStripSeparator3
			// 
			this->toolStripSeparator3->Name = L"toolStripSeparator3";
			this->toolStripSeparator3->Size = System::Drawing::Size(206, 6);
			// 
			// вырезатьToolStripMenuItem
			// 
			this->вырезатьToolStripMenuItem->Image = (cli::safe_cast<System::Drawing::Image^  >(resources->GetObject(L"вырезатьToolStripMenuItem.Image")));
			this->вырезатьToolStripMenuItem->ImageTransparentColor = System::Drawing::Color::Magenta;
			this->вырезатьToolStripMenuItem->Name = L"вырезатьToolStripMenuItem";
			this->вырезатьToolStripMenuItem->ShortcutKeys = static_cast<System::Windows::Forms::Keys>((System::Windows::Forms::Keys::Control | System::Windows::Forms::Keys::X));
			this->вырезатьToolStripMenuItem->Size = System::Drawing::Size(209, 22);
			this->вырезатьToolStripMenuItem->Text = L"Вырезат&ь";
			// 
			// копироватьToolStripMenuItem
			// 
			this->копироватьToolStripMenuItem->Image = (cli::safe_cast<System::Drawing::Image^  >(resources->GetObject(L"копироватьToolStripMenuItem.Image")));
			this->копироватьToolStripMenuItem->ImageTransparentColor = System::Drawing::Color::Magenta;
			this->копироватьToolStripMenuItem->Name = L"копироватьToolStripMenuItem";
			this->копироватьToolStripMenuItem->ShortcutKeys = static_cast<System::Windows::Forms::Keys>((System::Windows::Forms::Keys::Control | System::Windows::Forms::Keys::C));
			this->копироватьToolStripMenuItem->Size = System::Drawing::Size(209, 22);
			this->копироватьToolStripMenuItem->Text = L"&Копировать";
			// 
			// вставкаToolStripMenuItem
			// 
			this->вставкаToolStripMenuItem->Image = (cli::safe_cast<System::Drawing::Image^  >(resources->GetObject(L"вставкаToolStripMenuItem.Image")));
			this->вставкаToolStripMenuItem->ImageTransparentColor = System::Drawing::Color::Magenta;
			this->вставкаToolStripMenuItem->Name = L"вставкаToolStripMenuItem";
			this->вставкаToolStripMenuItem->ShortcutKeys = static_cast<System::Windows::Forms::Keys>((System::Windows::Forms::Keys::Control | System::Windows::Forms::Keys::V));
			this->вставкаToolStripMenuItem->Size = System::Drawing::Size(209, 22);
			this->вставкаToolStripMenuItem->Text = L"Вст&авка";
			// 
			// toolStripSeparator4
			// 
			this->toolStripSeparator4->Name = L"toolStripSeparator4";
			this->toolStripSeparator4->Size = System::Drawing::Size(206, 6);
			// 
			// выделитьвсеToolStripMenuItem
			// 
			this->выделитьвсеToolStripMenuItem->Name = L"выделитьвсеToolStripMenuItem";
			this->выделитьвсеToolStripMenuItem->Size = System::Drawing::Size(209, 22);
			this->выделитьвсеToolStripMenuItem->Text = L"Выделить &все";
			// 
			// сервисToolStripMenuItem
			// 
			this->сервисToolStripMenuItem->DropDownItems->AddRange(gcnew cli::array< System::Windows::Forms::ToolStripItem^  >(2) {this->настройкиToolStripMenuItem, 
				this->параметрыToolStripMenuItem});
			this->сервисToolStripMenuItem->Name = L"сервисToolStripMenuItem";
			this->сервисToolStripMenuItem->Size = System::Drawing::Size(59, 20);
			this->сервисToolStripMenuItem->Text = L"&Сервис";
			// 
			// настройкиToolStripMenuItem
			// 
			this->настройкиToolStripMenuItem->Name = L"настройкиToolStripMenuItem";
			this->настройкиToolStripMenuItem->Size = System::Drawing::Size(138, 22);
			this->настройкиToolStripMenuItem->Text = L"&Настройки";
			// 
			// параметрыToolStripMenuItem
			// 
			this->параметрыToolStripMenuItem->Name = L"параметрыToolStripMenuItem";
			this->параметрыToolStripMenuItem->Size = System::Drawing::Size(138, 22);
			this->параметрыToolStripMenuItem->Text = L"&Параметры";
			// 
			// справкаToolStripMenuItem
			// 
			this->справкаToolStripMenuItem->DropDownItems->AddRange(gcnew cli::array< System::Windows::Forms::ToolStripItem^  >(5) {this->содержаниеToolStripMenuItem, 
				this->индексToolStripMenuItem, this->поискToolStripMenuItem, this->toolStripSeparator5, this->опрограммеToolStripMenuItem});
			this->справкаToolStripMenuItem->Name = L"справкаToolStripMenuItem";
			this->справкаToolStripMenuItem->Size = System::Drawing::Size(65, 20);
			this->справкаToolStripMenuItem->Text = L"Спра&вка";
			// 
			// содержаниеToolStripMenuItem
			// 
			this->содержаниеToolStripMenuItem->Name = L"содержаниеToolStripMenuItem";
			this->содержаниеToolStripMenuItem->Size = System::Drawing::Size(158, 22);
			this->содержаниеToolStripMenuItem->Text = L"&Содержание";
			// 
			// индексToolStripMenuItem
			// 
			this->индексToolStripMenuItem->Name = L"индексToolStripMenuItem";
			this->индексToolStripMenuItem->Size = System::Drawing::Size(158, 22);
			this->индексToolStripMenuItem->Text = L"&Индекс";
			// 
			// поискToolStripMenuItem
			// 
			this->поискToolStripMenuItem->Name = L"поискToolStripMenuItem";
			this->поискToolStripMenuItem->Size = System::Drawing::Size(158, 22);
			this->поискToolStripMenuItem->Text = L"&Поиск";
			// 
			// toolStripSeparator5
			// 
			this->toolStripSeparator5->Name = L"toolStripSeparator5";
			this->toolStripSeparator5->Size = System::Drawing::Size(155, 6);
			// 
			// опрограммеToolStripMenuItem
			// 
			this->опрограммеToolStripMenuItem->Name = L"опрограммеToolStripMenuItem";
			this->опрограммеToolStripMenuItem->Size = System::Drawing::Size(158, 22);
			this->опрограммеToolStripMenuItem->Text = L"&О программе...";
			this->опрограммеToolStripMenuItem->Click += gcnew System::EventHandler(this, &Form1::опрограммеToolStripMenuItem_Click);
			// 
			// label2
			// 
			this->label2->Font = (gcnew System::Drawing::Font(L"Microsoft Sans Serif", 12, System::Drawing::FontStyle::Bold, System::Drawing::GraphicsUnit::Point, 
				static_cast<System::Byte>(204)));
			this->label2->ForeColor = System::Drawing::Color::Red;
			this->label2->Location = System::Drawing::Point(67, 175);
			this->label2->Name = L"label2";
			this->label2->Size = System::Drawing::Size(188, 28);
			this->label2->TabIndex = 3;
			this->label2->Text = L"DateTime";
			this->label2->TextAlign = System::Drawing::ContentAlignment::MiddleCenter;
			// 
			// label3
			// 
			this->label3->Font = (gcnew System::Drawing::Font(L"Microsoft Sans Serif", 12, System::Drawing::FontStyle::Bold, System::Drawing::GraphicsUnit::Point, 
				static_cast<System::Byte>(204)));
			this->label3->ForeColor = System::Drawing::Color::DodgerBlue;
			this->label3->Location = System::Drawing::Point(94, 129);
			this->label3->Name = L"label3";
			this->label3->Size = System::Drawing::Size(100, 23);
			this->label3->TabIndex = 4;
			this->label3->Text = L"Сегодня";
			this->label3->TextAlign = System::Drawing::ContentAlignment::MiddleCenter;
			// 
			// label4
			// 
			this->label4->Font = (gcnew System::Drawing::Font(L"Microsoft Sans Serif", 12, System::Drawing::FontStyle::Bold, System::Drawing::GraphicsUnit::Point, 
				static_cast<System::Byte>(204)));
			this->label4->ForeColor = System::Drawing::Color::ForestGreen;
			this->label4->Location = System::Drawing::Point(94, 27);
			this->label4->Name = L"label4";
			this->label4->Size = System::Drawing::Size(100, 23);
			this->label4->TabIndex = 5;
			this->label4->Text = L"Сейчас";
			this->label4->TextAlign = System::Drawing::ContentAlignment::MiddleCenter;
			// 
			// labelDay
			// 
			this->labelDay->Font = (gcnew System::Drawing::Font(L"Microsoft Sans Serif", 12, System::Drawing::FontStyle::Bold, System::Drawing::GraphicsUnit::Point, 
				static_cast<System::Byte>(204)));
			this->labelDay->ForeColor = System::Drawing::Color::MediumVioletRed;
			this->labelDay->Location = System::Drawing::Point(85, 152);
			this->labelDay->Name = L"labelDay";
			this->labelDay->Size = System::Drawing::Size(136, 23);
			this->labelDay->TabIndex = 6;
			this->labelDay->Text = L"Day";
			this->labelDay->TextAlign = System::Drawing::ContentAlignment::MiddleCenter;
			// 
			// Form1
			// 
			this->AutoScaleDimensions = System::Drawing::SizeF(6, 13);
			this->AutoScaleMode = System::Windows::Forms::AutoScaleMode::Font;
			this->AutoSize = true;
			this->BackColor = System::Drawing::Color::White;
			this->ClientSize = System::Drawing::Size(284, 205);
			this->Controls->Add(this->labelDay);
			this->Controls->Add(this->label4);
			this->Controls->Add(this->label3);
			this->Controls->Add(this->label2);
			this->Controls->Add(this->button1);
			this->Controls->Add(this->label1);
			this->Controls->Add(this->menuStrip1);
			this->ForeColor = System::Drawing::Color::SaddleBrown;
			this->Icon = (cli::safe_cast<System::Drawing::Icon^  >(resources->GetObject(L"$this.Icon")));
			this->MainMenuStrip = this->menuStrip1;
			this->Name = L"Form1";
			this->StartPosition = System::Windows::Forms::FormStartPosition::CenterScreen;
			this->Text = L"WinFormC++Clock";
			this->menuStrip1->ResumeLayout(false);
			this->menuStrip1->PerformLayout();
			this->ResumeLayout(false);
			this->PerformLayout();

		}
#pragma endregion
	private: System::String^ Day(DayOfTheWeek type)
	{
      switch(type)
	  {
	  case Воскресение:
		  return "Воскресение";
		  break;
	  case Понедельник:
		  return "Понедельник";
		  break;
	  case Вторник:
		  return "Вторник";
		  break;
	  case Среда:
		  return "Среда";
		  break;
	  case Четверг:
		  return "Четверг";
		  break;
	  case Пятница:
		  return "Пятница";
		  break;
	  case Субота:
		  return "Субота";
		  break;
	  default:
		  return "Empty";
	  }
	}
		
	private: System::Void button1_Click(System::Object^  sender, System::EventArgs^  e) {
				 label1->Text = L"15:00:00";
				  timer1->Enabled = true;
				  timer1->Interval = 1000;
			 }
			
	private: System::Void timer1_Tick(System::Object^  sender, System::EventArgs^  e) {

				 System::DateTime dt ;
				 label1->Text = dt.Now.ToLongTimeString();
				 label2->Text = dt.Now.ToLongDateString();
				/* labelDay->Text = dt.Now.DayOfWeek.ToString();*/
				 DayOfTheWeek d = DayOfTheWeek(dt.Now.DayOfWeek);
				 labelDay->Text = Day(d);
				/* int d = (int)dt.Now.DayOfWeek;
				 labelDay->Text = d.ToString();*/
			 }
private: System::Void опрограммеToolStripMenuItem_Click(System::Object^  sender, System::EventArgs^  e) {
			
		 }
};
}

