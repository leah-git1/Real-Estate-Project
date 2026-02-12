//בכדי לאפשר קלט
#include <iostream>//בכדי לאפשר פלט
#include <math.h>//לאפשר שימוש בפונקציות מתמטיות
using namespace std;

#pragma once
class A
{
private:
	int* a;
	int s;

public:
	//ctor
	A(int* arr,int s) {
		this->s = s;
		a = new int[s];
		for (int i = 0; i < s; i++) {
			this->a[i] = arr[i];
		}
		cout << "ctor\n";
	}

	//copy ctor
	A(const A& aa) {

		this->s = aa.s;
		a = new int[s];
		for (int i = 0; i < s; i++) {
			this->a[i] = aa.a[i];
		}
		cout << "copy ctor\n";
	}

	//operator=
	A& operator=(const A& b) {
		if (a != nullptr)
			delete[]a;
		this->s = b.s;
		a = new int[s];
		for (int i = 0; i < s; i++) {
			this->a[i] = b.a[i];
		}
		cout << "operator=\n";
		return*this;
	}

	//move ctor
	A(A&& b) :s(b.s){
		this->a = b.a;
		b.a = nullptr;
		cout << "move ctor\n";
	}

	//move operator=
	A& operator=(A&& b) {
		if (a!= nullptr)
			delete []a;
		this->s = b.s;
		this->a = b.a;
		b.a = nullptr;
		cout << "move operator=\n";
		return*this;
	}

	//dtor
	~A()
	{
		if (a!= nullptr)
			delete[]a;
		cout << "dtor\n";
	}
};
A& bb(A& aa) {
	return aa;
}

void main() {
	int arr[] = { 1,2,3 };
	int arr2[] = { 1,2,3 ,4,5};
	A a(arr, 3);
	A b(arr2,4);
	move(a = bb(a));
}
