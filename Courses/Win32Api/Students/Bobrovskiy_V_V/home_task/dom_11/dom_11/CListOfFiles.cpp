#include "CListOfFiles.h"
#include <fstream>
//-------------------------
CListOfFiles::CListOfFiles() {
///-----

};
//---
CListOfFiles::~CListOfFiles(){
///------

};
//---
void CListOfFiles::removeFile(std::string fileName){
///------
	remove(fileName.c_str());
};
//---
void CListOfFiles::createListOfFiles(std::string dirName){
///------
	std::string path = 	dirName;
	// Запросим маску файлов 
	std::string mask("*.txt");
	// Соединив две строки, мы получим результат
	// т.е. что хочет найти пользователь и где
	std::string fullpath;
	 fullpath.assign(path);
	  fullpath.append(mask);
	//strcat(path, mask);
		
	// Объявление указателя fileinfo на структуру _finddata_t
	// и создание динамического объекта структуры _finddata_t
    _finddata_t *fileinfo=new _finddata_t;	

	// Начинаем поиск
	long done = _findfirst(fullpath.c_str(),fileinfo);

	// если done будет равняться -1, 
	// то поиск вести бесмысленно
	int MayWeWork = done;	

	// Счетчик, содержит информацию о количестве найденых файлов.	
	int count = 0;   
	while (MayWeWork!=-1) {	
		count++;
		//AnsiToOem(fileinfo->name,fileinfo->name);
		this->listOfFiles.push_back(fileinfo->name);
		//cout << fileinfo->name << "\n\n"; 
		// Пытаемся найти следующий файл из группы
		MayWeWork = _findnext(done, fileinfo);        
	}
	// Очистка памяти
	_findclose(done);
	delete fileinfo;

};
//---
std::vector<std::string>& CListOfFiles::getListOfFiles(){
///------
	return this->listOfFiles;
};
//---
void CListOfFiles::writedatatofile( inStrucData& datastruct) {
///--------
	std::basic_string<TCHAR> filename;
	//--- form file name --
	//filename.append("..\\formlist\\");
	filename.append(datastruct.Name);
	filename.append("_");
	filename.append(datastruct.Surname);
	filename.append("_");
	filename.append(datastruct.ThirdName);
	filename.append(".txt");
	//--------------------------------
	HANDLE hFile = NULL;
	DWORD dwResult = 0;
	//::SetCurrentDirectory("..\\formlist\\");
	hFile = CreateFile(filename.c_str(),       // name of the write
                       GENERIC_WRITE,          // open for writing
                       0,                      // do not share
                       NULL,                   // default security
                       CREATE_ALWAYS,          // overwrite existing
                       FILE_ATTRIBUTE_NORMAL,  // normal file
                       NULL);                  // no attr. template

    if (hFile == INVALID_HANDLE_VALUE) { 
        throw "Could not open file (error %d)\n";
        return;
    }
    if(!WriteFile (hFile, datastruct.Name, strlen(datastruct.Name), &dwResult, NULL)) {
        throw "Could not write to file (error %d)\n";
        return;
    }
	//---------
	WriteFile (hFile, "\r\n", strlen("\r\n"), &dwResult, NULL);
	WriteFile (hFile, datastruct.Surname, strlen(datastruct.Surname), &dwResult, NULL);
	WriteFile (hFile, "\r\n", strlen("\r\n"), &dwResult, NULL);
	WriteFile (hFile, datastruct.ThirdName, strlen(datastruct.ThirdName), &dwResult, NULL);
	WriteFile (hFile, "\r\n", strlen("\r\n"), &dwResult, NULL);
	WriteFile (hFile, datastruct.Gender, strlen(datastruct.Gender), &dwResult, NULL);
	WriteFile (hFile, "\r\n", strlen("\r\n"), &dwResult, NULL);
	WriteFile (hFile, datastruct.Phone, strlen(datastruct.Phone), &dwResult, NULL);
	WriteFile (hFile, "\r\n", strlen("\r\n"), &dwResult, NULL);
	WriteFile (hFile, datastruct.Nationality, strlen(datastruct.Nationality), &dwResult, NULL);
	WriteFile (hFile, "\r\n", strlen("\r\n"), &dwResult, NULL);
	WriteFile (hFile, datastruct.FamilyState, strlen(datastruct.FamilyState), &dwResult, NULL);
	WriteFile (hFile, "\r\n", strlen("\r\n"), &dwResult, NULL);
	WriteFile (hFile, datastruct.Adress, strlen(datastruct.Adress), &dwResult, NULL);
	WriteFile (hFile, "\r\n", strlen("\r\n"), &dwResult, NULL);
	WriteFile (hFile, datastruct.PhotoPath, strlen(datastruct.PhotoPath), &dwResult, NULL);
	//---------
	::CloseHandle(hFile);
	//::CloseFile();	

};
inputedData& CListOfFiles::readdatafromfile(std::string fileName) {
///--------
	inputedData data;	

	std::basic_string<TCHAR> fullname;
	fullname.append("..\\formlist\\");
	fullname.append(fileName);
	//---------
	const int BUF_SIZE = 760;
	 DWORD dwBytesRead = 0;
      char buf[BUF_SIZE];
	   HANDLE hFile = NULL;
	//---------
	 hFile = CreateFile(fullname.c_str(),               // file to open
                       GENERIC_READ|GENERIC_WRITE,          // open for reading
                       FILE_SHARE_READ,       // share for reading
                       NULL,                  // default security
                       OPEN_EXISTING,         // existing file only
                       FILE_ATTRIBUTE_NORMAL, // normal file
                       NULL);                 // no attr. template
 
    if (hFile == INVALID_HANDLE_VALUE) { 
       throw "Could not open file (error %d)\n";
    }

    if(!ReadFile(hFile, buf, BUF_SIZE, &dwBytesRead, NULL)) {
        throw "Could not read from file (error %d)\n";       
    }
    buf[dwBytesRead]='\0';
	::CloseHandle(hFile);
	//----------
	strcpy(data.Name,strtok(buf,"\n"));
	data.Name[strlen(data.Name)-1] = '\0';
	//---
	strcpy(data.Surname,strtok(NULL,"\n"));
	data.Surname[strlen(data.Surname)-1] = '\0';
	//---
	strcpy(data.ThirdName,strtok(NULL,"\n"));
	data.ThirdName[strlen(data.ThirdName)-1] = '\0';
	//---
	strcpy(data.Gender,strtok(NULL,"\n"));
	data.Gender[strlen(data.Gender)-1] = '\0';
	//---
	strcpy(data.Phone,strtok(NULL,"\n"));
	data.Phone[strlen(data.Phone)-1] = '\0';
	//---
	strcpy(data.Nationality,strtok(NULL,"\n"));
	data.Nationality[strlen(data.Nationality)-1] = '\0';
	//---
	strcpy(data.FamilyState,strtok(NULL,"\n"));
	data.FamilyState[strlen(data.FamilyState)-1] = '\0';
	//---
	strcpy(data.Adress,strtok(NULL,"\n"));
	data.Adress[strlen(data.Adress)-1] = '\0';
	//---
	strcpy(data.PhotoPath,strtok(NULL,"\n"));
	data.PhotoPath[strlen(data.PhotoPath)] = '\0';
	//---
	//::CloseFile();		
return data;

};