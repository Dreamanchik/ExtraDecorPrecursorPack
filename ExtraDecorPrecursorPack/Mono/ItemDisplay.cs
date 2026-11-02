using UnityEngine;

namespace ExtraDecorPrecursorPack.Mono
{
    internal class ItemDisplay : MonoBehaviour
    {
        private StorageContainer storageContainer;
        private bool initialized;
        private GameObject model;
        public Vector3 pos = Vector3.zero;
        public Vector3 size = Vector3.one;
        public Vector3 rot = Vector3.zero;
        private void Awake()
        {
            this.storageContainer = base.GetComponent<StorageContainer>();
        }
        private void OnEnable()
        {
            bool flag = !this.initialized;
            if (flag)
            {
                this.storageContainer.enabled = true;
                this.storageContainer.container.onAddItem += new OnAddItem(this.AddItem);
                this.storageContainer.container.onRemoveItem += new OnRemoveItem(this.RemoveItem);
                this.initialized = true;
            }
        }
        private void AddItem(InventoryItem item)
        {
            this.storageContainer.Resize(item.width, item.height);
            this.Spawn(item.item.gameObject);
        }
        private void RemoveItem(InventoryItem item)
        {
            this.storageContainer.Resize(10, 20);
            Object.Destroy(this.model);
        }
        private void Spawn(GameObject obj)
        {
            TechType techType = obj.GetComponent<Pickupable>().GetTechType();
            this.model = Object.Instantiate<GameObject>(obj);
            Object.Destroy(this.model.GetComponent<Rigidbody>());
            Object.Destroy(this.model.GetComponent<WorldForces>());
            Object.Destroy(this.model.GetComponent<PrefabIdentifier>());
            Object.Destroy(this.model.GetComponent<LargeWorldEntity>());
            Object.Destroy(this.model.GetComponent<LiveMixin>());
            Object.Destroy(this.model.GetComponent<Locomotion>());
            Object.Destroy(this.model.GetComponent<SwimBehaviour>());
            this.model.transform.parent = base.gameObject.transform;
            this.model.transform.localPosition = this.pos;
            this.model.transform.localScale = this.size;
            this.model.transform.localEulerAngles = this.rot;
            this.model.SetActive(true);
        }
    }
}
