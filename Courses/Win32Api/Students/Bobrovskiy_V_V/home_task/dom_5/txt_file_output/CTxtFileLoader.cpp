#include "CTxtFileLoader.h"
#include <fstream>
#include <io.h>
const int buf_size=2000;
//-------------------------
int CTxtFileLoader::GetFileSize(const std::string txtFileName) {
	FILE * file = fopen(txtFileName.c_str(), "rb");
	int handle = _fileno(file);
	this->fileSize = _filelength(handle);
	fclose(file);	
	return 0;
};
//--
void CTxtFileLoader::init(const std::string txtFileName) {
	std::ifstream input(txtFileName.c_str());
	//---
	GetFileSize(txtFileName);
	//---
	char buf[buf_size];
	//---
	this->currentFilePos.push_back(input.tellg());
	this->pageNumber = 0;
	//---
	while(input.good()){
	 for(int i=0; (i<this->pageSize)&&(input.good()); ++i) {
		input.getline(buf,buf_size);		
		this->page.push_back(buf);		
	}
	 if(!this->page.empty()) this->page.clear();
	  this->currentFilePos.push_back(input.tellg());
	}
	//--
	 lineLenMax = buf_size/2;
	//--
	input.close();
}
//--
CTxtFileLoader::CTxtFileLoader() {
	this->pageNumber = 0;
	this->fileName = "readme.txt";
	init(this->fileName);
};
CTxtFileLoader::CTxtFileLoader(const std::string txtFileName) {
//--------------
	this->fileName = txtFileName;
	init(this->fileName);
}; 
//---
void CTxtFileLoader::operator ()(const std::string txtFileName) {
	this->fileName = txtFileName;
	init(this->fileName);
};
CTxtFileLoader::~CTxtFileLoader() {

}; 
//---
void CTxtFileLoader::LoadNextPage() {
 
	std::ifstream input(this->fileName.c_str());
	
	char b[10];
   
	 if(!this->page.empty())   this->page.clear();
	//---
	  char buf[buf_size];
	  if((this->currentFilePos.size()-1)>this->pageNumber) ++this->pageNumber;
		  
	  input.seekg(this->currentFilePos[this->pageNumber]);
	
	  for(int i=0; (i<this->pageSize)&&(input.good()); ++i) {
		input.getline(buf,buf_size);		
		this->page.push_back(buf);		
	}
	//---
	  lineLenMax = buf_size/2;
	for (int i = 0; i <this->page.size(); ++i) {
		int lineLen = this->page[i].size();
		// if \t simbol are in text
		int iTabPos = 0;
		while (1) {
			iTabPos = this->page[i].find('\t', iTabPos);
			if (iTabPos != -1) {
				lineLen += 8;
				iTabPos++;
			}
			else  break;
		}
		if (lineLen > lineLenMax)  lineLenMax = lineLen;
	}

	//---
	input.close();
};
//---
void CTxtFileLoader::LoadPrevPage() {

	if(this->pageNumber>0) 	
	--this->pageNumber;
	 
	std::ifstream input(this->fileName.c_str());
	
	if(this->pageNumber==0) input.seekg(this->currentFilePos[0]);
	else if((this->pageNumber>0)&&(this->currentFilePos.size()>=this->pageNumber)) input.seekg(this->currentFilePos[this->pageNumber]);
	 
	if(!this->page.empty()) this->page.clear();
	  char buf[buf_size];
	//---
	for(int i=0; (i<=this->pageSize)&&(input.good()); ++i) {
		input.getline(buf,buf_size);		
		this->page.push_back(buf);		
	}
	//---
	if(this->pageNumber==0) input.seekg(0);
	else input.seekg(this->currentFilePos[this->pageNumber]);
	//---
	  lineLenMax = buf_size/2;
	for (int i = 0; i <this->page.size(); ++i) {
		int lineLen = this->page[i].size();
		// if \t simbol are in text
		int iTabPos = 0;
		while (1) {
			iTabPos = this->page[i].find('\t', iTabPos);
			if (iTabPos != -1) {
				lineLen += 8;
				iTabPos++;
			}
			else  break;
		}
		if (lineLen > lineLenMax)  lineLenMax = lineLen;
	}
	//---
	input.close();
	
};
//---
void CTxtFileLoader::FormatTextOutput(HWND hWnd) {

};
//---
const LOGFONT CTxtFileLoader::DefineFont(HWND hWnd){
	LOGFONT tmpFont;
	
    tmpFont.lfHeight = 16;
    tmpFont.lfWidth =8;
    tmpFont.lfEscapement =0;
    tmpFont.lfOrientation =0;
    tmpFont.lfWeight = FW_NORMAL;
    tmpFont.lfItalic = false;
    tmpFont.lfUnderline = false;
    tmpFont.lfStrikeOut = false;
    tmpFont.lfCharSet = RUSSIAN_CHARSET;
    tmpFont.lfOutPrecision = OUT_DEFAULT_PRECIS;
    tmpFont.lfClipPrecision  = CLIP_DEFAULT_PRECIS;
    tmpFont.lfQuality = CLEARTYPE_QUALITY;
    tmpFont.lfPitchAndFamily = DEFAULT_PITCH;
	lstrcpy(tmpFont.lfFaceName,"Times");

	return tmpFont;
};
//---
void CTxtFileLoader::DrawPageText(HWND hWnd) {

	HDC hDC = ::GetDC(hWnd);
	RECT rect;
	GetClientRect(hWnd, &rect);

	HBRUSH hBrush = CreateSolidBrush(RGB(255,255,255));
	::FillRect(hDC,&rect,hBrush);

	rect.left += cxChar;
	rect.right -= cxChar;
	
	int x = cxChar * (hsi.nMin - hsi.nPos + 1)+10;
	int y = yStep;
	//---
	LOGFONT logFont = DefineFont(hWnd);
	HFONT hFon = ::CreateFontIndirect(&logFont);
	HFONT oldFont = (HFONT)::SelectObject(hDC,hFon);			
	//---	
	int amountLines = this->page.size();
	int iBeg = vsi.nPos;
	int iEnd = (vsi.nPos+vsi.nPage < amountLines)? vsi.nPos+vsi.nPage : amountLines;
	for (int i = iBeg; i < iEnd; ++i) {
		int iTabPos = this->page[i].find('\t');
		if (-1 == iTabPos)
			TextOut(hDC, x, y, this->page[i].c_str(), this->page[i].size());
		else
			TabbedTextOut(hDC, x, y, this->page[i].c_str(), this->page[i].size(), 0, 0, x);
		y += yStep;
	}
	//---
	::SelectObject(hDC,oldFont);
	::DeleteObject(hFon);	
	::ReleaseDC(hWnd,hDC);

};
//-------------------------
void CTxtFileLoader::Initialize(LPTEXTMETRIC tm) {
	cxChar = tm->tmAveCharWidth;
	yStep = tm->tmHeight + tm->tmExternalLeading;
	vsi.nMin = vsi.nPos = 0;
	hsi.nMin = hsi.nPos = 0;
}

void CTxtFileLoader::ScrollSettings(HWND hwnd, int width, int height) {

	// Вертикальный скроллинг
	vsi.cbSize = sizeof(vsi);
	vsi.fMask = SIF_RANGE | SIF_PAGE | SIF_POS;
	vsi.nPage = height / yStep - 1;
	vsi.nMax = this->page.size() - 1;
	if (vsi.nPage > vsi.nMax)
		vsi.nPos = vsi.nMin;
	vertRange = vsi.nMax - vsi.nMin + 1;
	SetScrollInfo(hwnd, SB_VERT, &vsi, TRUE);

	// Горизонтальный скроллинг
	hsi.cbSize = sizeof(SCROLLINFO);
	hsi.fMask = SIF_RANGE | SIF_PAGE | SIF_POS;
	hsi.nPage = width/cxChar - 2;
	hsi.nMax = lineLenMax;
	if (hsi.nPage > hsi.nMax)
		hsi.nPos = hsi.nMin;
	horzRange = hsi.nMax - hsi.nMin + 1;
	SetScrollInfo(hwnd, SB_HORZ, &hsi, TRUE);
}

void CTxtFileLoader::UpdateVscroll(HWND hwnd, int yInc) {
	// ограничение на положительное приращение
	yInc = min(yInc, vertRange - (int)vsi.nPage - vsi.nPos);
	// ограничение на отрицательное приращение
	yInc = max(yInc, vsi.nMin - vsi.nPos);

	if (yInc) {
		ScrollWindow(hwnd, 0, -yStep * yInc, NULL, NULL); 
		vsi.nPos += yInc;
		SetScrollInfo(hwnd, SB_VERT, &vsi, TRUE);
		InvalidateRect(hwnd, NULL, TRUE);
		UpdateWindow (hwnd); 
	} 
}

void CTxtFileLoader::UpdateHscroll(HWND hwnd, int xInc) {
	// ограничение на положительное приращение
	xInc = min(xInc, horzRange - (int)hsi.nPage - hsi.nPos);
	// ограничение на отрицательное приращение
	xInc = max(xInc, hsi.nMin - hsi.nPos);

	if (xInc) {
		ScrollWindow(hwnd, -cxChar * xInc, 0, NULL, NULL); 
		hsi.nPos += xInc;
		SetScrollInfo(hwnd, SB_HORZ, &hsi, TRUE);
		InvalidateRect(hwnd, NULL, TRUE);
		UpdateWindow (hwnd); 
	} 
}
//-----------------------
