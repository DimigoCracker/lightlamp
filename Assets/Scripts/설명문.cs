/*
    Trampoline에 있던 Capsule Collider 삭제
        그거 때문에 공중에 둥둥떠있어서 10분낭비당함 ㅠ...
        대신 Trmapoline_up에 Mesh Collider 넣어둠 
    Trampoline_up을 만듬
        Trampoline에 그냥 넣으면 옆면에 닿아도 y값 백터를 받기때문에 그냥 Trampoline위에 얆은
        막을 덮어둠. 
    Trampoline_up에 리지드바디 추가
        리지드바디 설정은 InKinematic을 켜놨고, 중력영향은 꺼둠
    Tag추가
        Trampoline_Tag라는 것을 만듬
    어떻게 만들었냐?
        Player에 Tranpoline이라는 스크립트를 붙혔고, 그 효과는 Tag가 Trampoline_Tag라는 것에
        닿을시 위로 y값 백터를 얻는 방식
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class 설명문 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
