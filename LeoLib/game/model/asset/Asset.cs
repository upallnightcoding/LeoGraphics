using LeoLib.game.model.asset;
using LeoLib.game.texture;
using OpenTK.Mathematics;

namespace LeoLib
{
    public abstract class Asset
    {
        private Transform transform = null;

        private Mesh mesh = null;

        private Behavior behavior = null;

        /*******************/
        /*** Constructor ***/
        /*******************/

        public Asset(Mesh mesh) : this(mesh, null)
        {
        }

        public Asset(Mesh mesh, Behavior behavior)
        {
            this.transform = new Transform();
            this.mesh = mesh;

            Add(behavior);
        }

        /**************************/
        /*** Abstract Functions ***/
        /**************************/

        public abstract void AssignTextures();

        public abstract void DeleteTextures();

        public abstract void CreateTextures();

        /************************/
        /*** Public Functions ***/
        /************************/

        public void Update(float deltaTime)
        {
            if (behavior != null)
            {
                behavior.Update(deltaTime, transform);
            }
        }

        public void Add(Behavior behavior)
        {
            if (behavior != null)
            {
                this.behavior = behavior;
            }
        }

        /// <summary>
        /// Check() - Checks the behavior states of the current asset.  This <br/>
        /// function allows the asset to traverse from one state to another.  <br/>
        /// The "context" object contains the current context of the render <br/>
        /// loop.
        /// </summary>
        /// 
        /// <param name="context"></param>
        public void Check(EventContext context)
        {
            if (behavior != null) { 
                behavior.Check(context);
            }
        }

        /// <summary>
        /// Construct() - Builds the mesh that is associated with the asset.  <br/>
        /// This is done by setting up the vbo, vao and possible ebo.  <br/>
        /// This also includes the binding and unbinding of all buffers.
        /// </summary>
        public void Construct()
        {
            CreateTextures();
            mesh.Contruct();
        }

        public void Render()
        {
            AssignTextures();
            mesh.Render();
        }

        public void OnUnLoad()
        {
            mesh.OnUnLoad();
            DeleteTextures();
        }

        public Matrix4 GetModel()
        {
            return (transform.GetModel());
        }

        /***************************/
        /*** Protected Functions ***/
        /***************************/

        /*protected void Rotate(float x, float y, float z)
        {
            transform.Rotate(x, y, z);
        }*/

        protected void AssetImageScale(TextureData data)
        {
            transform.Scale(1.0f, data.Scale(), 1.0f);
        }

        /*************************/
        /*** Private Functions ***/
        /*************************/

        /// <summary>
        /// BindVao() - Binds the VAO of the mesh.  This is used during the <br/>
        /// execution of the shader that is associated with the asset.  <br/>
        /// Only one shader can be associated with a asset.
        /// </summary>
        public void BindVao()
        {
            mesh.BindVao();
        }
    }
}
