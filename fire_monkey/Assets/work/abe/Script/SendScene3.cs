namespace VRTK.Examples
{
    using UnityEngine;
    using UnityEngine.SceneManagement;

    public class SendScene3 : VRTK_InteractableObject
    {
        public bool flipped = false;
        public bool rotated = false;

        private float sideFlip = -1;
        private float side = -1;
        private float smooth = 270.0f;
        private float doorOpenAngle = 90f;
        private bool open = false;
        private float time = 0;

        private Vector3 defaultRotation;
        private Vector3 openRotation;

        public override void StartUsing(VRTK_InteractUse usingObject)
        {
            base.StartUsing(usingObject);
            SetDoorRotation(usingObject.transform.position);
            SetRotation();
            open = !open;
        }

        protected void Start()
        {
            defaultRotation = transform.eulerAngles;
            SetRotation();
            sideFlip = (flipped ? 1 : -1);
        }

        protected override void Update()
        {
            base.Update();
            if (open)
            {
                transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(openRotation), Time.deltaTime * smooth);
                time += Time.deltaTime;

                //ホワイトアウト処理
                SteamVR_Fade.Start(Color.white, 2f);

                //ホワイトアウト終了後メインシーンへ
                if (time > 2)
                {
                    SceneManager.LoadScene("school5");
                }
            }
            else
            {
                transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(defaultRotation), Time.deltaTime * smooth);
            }
        }

        private void SetRotation()
        {
            openRotation = new Vector3(defaultRotation.x, defaultRotation.y + (doorOpenAngle * (sideFlip * side)), defaultRotation.z);
        }

        private void SetDoorRotation(Vector3 interacterPosition)
        {
            side = -1;//((rotated == false && interacterPosition.z > transform.position.z) || (rotated == true && interacterPosition.x > transform.position.x) ? -1 : 1);
        }
    }
}
